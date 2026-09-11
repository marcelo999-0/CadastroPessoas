using CadastroPessoas.API.Models;
using CadastroPessoas.API.Service;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroPessoas.API.Service
{
    public class PessoasCadastro(string connectionString)
    {
        private SqlConnection _connection = null!;
        private SqlTransaction _trans = null!;

        private readonly string? _connectionString = connectionString;

        private void OpenConnection()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        private void BeginTransaction()
        {
            if (_connection is null || _connection.State != System.Data.ConnectionState.Open)
                OpenConnection();

            _trans ??= _connection?.BeginTransaction()!;
        }

        private void Commit()
        {
            _trans?.Commit();
        }

        private void Rollback()
        {
            _trans?.Rollback();
        }

        private SqlCommand CreateCommand(string sql)
        {
            return new SqlCommand(sql, _connection, _trans);
        }


        public void CriarPessoa(Pessoa pessoa)
        {
            const string query = @"INSERT INTO Pessoas (Nome, CPF, DataNascimento, Email)
                                   OUTPUT inserted.id     
                                   VALUES (@Nome, @CPF, @DataNascimento, @Email)";
            try
            {
                //using var connection = new SqlConnection(_connectionString);
                //using var command = new SqlCommand(query, connection);
                OpenConnection();
                BeginTransaction();

                using var command = CreateCommand(query);

                command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                command.Parameters.AddWithValue("@CPF", pessoa.CPF);
                command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                command.Parameters.AddWithValue("@Email", pessoa.Email);

                //connection.Open();
                int idPersona = Convert.ToInt32(command.ExecuteScalar());

                foreach (Endereco e in pessoa.Enderecos)
                    CriarEndereco(e, idPersona);

                foreach (Telefone t in pessoa.Telefones)
                    CriarTelefone(t, idPersona);

                Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        private void CriarTelefone(Telefone telefone, int pessoaId)
        {
            const string query = @"INSERT INTO Telefones (PessoaId, DDD, Numero, Tipo) 
                                   VALUES (@pessoaId, @DDD, @NumeroCasa, @Tipo)";
            //using var connection = new SqlConnection(_connectionString);
            //using var command = new SqlCommand(query, connection);
            using var command = CreateCommand(query);

            command.Parameters.AddWithValue("@pessoaId", pessoaId);
            command.Parameters.AddWithValue("@DDD", telefone.DDD);
            command.Parameters.AddWithValue("@NumeroCasa", telefone.Numero);
            command.Parameters.AddWithValue("@Tipo", telefone.Tipo);

            //connection.Open();
            command.ExecuteNonQuery();

        }

        private void CriarEndereco(Endereco endereco, int pessoaId)
        {
            const string query = @"INSERT INTO Enderecos (PessoaId, NumeroCasa, Bairro, Logradouro, UF, CEP, Cidade) 
                                   VALUES (@PessoaId, @NumeroCasa, @Bairro, @Logradouro, @UF, @CEP, @Cidade)";

            //using var connection = new SqlConnection(_connectionString);
            //using var command = new SqlCommand(query, connection);

            using var command = CreateCommand(query);

            command.Parameters.AddWithValue("@PessoaId", pessoaId);
            command.Parameters.AddWithValue("@NumeroCasa", endereco.NumeroCasa);
            command.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            command.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            command.Parameters.AddWithValue("@UF", endereco.UF);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);
            command.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            //connection.Open();
            command.ExecuteNonQuery();
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            const string query = @"UPDATE Pessoas SET 
                                Nome = @Nome, 
                                CPF = @CPF, 
                                DataNascimento = @DataNascimento, 
                                Email = @Email
                                WHERE Id = @Id";


            //using var connection = new SqlConnection(_connectionString);
            //using var command = new SqlCommand(query, connection);
            OpenConnection();
            BeginTransaction();

            using var command = CreateCommand(query);

            command.Parameters.AddWithValue("@Nome", pessoa.Nome);
            command.Parameters.AddWithValue("@CPF", pessoa.CPF);
            command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
            command.Parameters.AddWithValue("@Email", pessoa.Email);

            // excluir endereços e telefones antigos
            const string queryExcluir = @"delete from Telefones where (PessoaId = @id);
                                        delete from Enderecos where (PessoaId = @id);";
            try

            {
                using (var commandExcluir = CreateCommand(queryExcluir))
                {
                    commandExcluir.Parameters.AddWithValue("@id", pessoa.Id);
                    commandExcluir.ExecuteNonQuery();


                    //connection.Open();
                    int idPersona = Convert.ToInt32(command.ExecuteScalar());

                    foreach (Endereco e in pessoa.Enderecos)
                        CriarEndereco(e, idPersona);

                    foreach (Telefone t in pessoa.Telefones)
                        CriarTelefone(t, idPersona);

                    Commit();
                }
            }
            catch
            {
                Rollback();
            }
        }



        public void ExcluirPessoa(int idPessoa)
        {
            const string queryExcluirFilhos = @"DELETE FROM Telefones WHERE PessoaId = @Id;
                                                DELETE FROM Enderecos WHERE PessoaId = @Id;";
            const string queryExcluirPessoa = @"DELETE FROM Pessoas WHERE Id = @Id";

            try
            {
                OpenConnection();
                BeginTransaction();

                using (var commandFilhos = CreateCommand(queryExcluirFilhos))
                {
                    commandFilhos.Parameters.AddWithValue("@Id", idPessoa);
                    commandFilhos.ExecuteNonQuery();
                }

                using (var commandPessoa = CreateCommand(queryExcluirPessoa))
                {
                    commandPessoa.Parameters.AddWithValue("@Id", idPessoa);
                    commandPessoa.ExecuteNonQuery();
                }
                Commit();
            }
            catch
            {
                Rollback();

                throw;
            }
        }
        public Pessoa? ObterPessoa(int idPessoa)
        {
            const string query = @"SELECT * FROM Pessoas WHERE Id = @Id";
            try
            {
                OpenConnection();
                using var command = CreateCommand(query);
                command.Parameters.AddWithValue("@Id", idPessoa);

                using var reader = command.ExecuteReader();
                if (!reader.Read())
                    return null;

                var pessoa = new Pessoa
                { 
                    Nome = reader["Nome"].ToString()!,
                    CPF = reader["CPF"].ToString()!,
                    DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                    Email = reader["Email"].ToString()!
                };
                pessoa.Id = Convert.ToInt32(reader["Id"]);
                


                const string queryTelefones = @"SELECT * FROM Telefones WHERE PessoaId = @Id";
                using (var commandTelefones = CreateCommand(queryTelefones))
                {
                    commandTelefones.Parameters.AddWithValue("@Id", idPessoa);
                    using var readerTelefones = commandTelefones.ExecuteReader();
                    while (readerTelefones.Read())
                    {
                        var telefone = new Telefone
                        {
                            DDD = readerTelefones["DDD"].ToString()!,
                            Numero = readerTelefones["Numero"].ToString()!,
                            Tipo = readerTelefones["Tipo"].ToString()!
                        };
                        
                    }
                }


                const string queryEnderecos = @"SELECT * FROM Enderecos WHERE PessoaId = @Id";
                using (var commandEnderecos = CreateCommand(queryEnderecos))
                {
                    commandEnderecos.Parameters.AddWithValue("@Id", idPessoa);
                    using var readerEnderecos = commandEnderecos.ExecuteReader();
                    while (readerEnderecos.Read())
                    {
                        var endereco = new Endereco
                        { 
                            NumeroCasa = readerEnderecos["NumeroCasa"].ToString()!,
                            Bairro = readerEnderecos["Bairro"].ToString()!,
                            Logradouro = readerEnderecos["Logradouro"].ToString()!,
                            UF = readerEnderecos["UF"].ToString()!,
                            CEP = readerEnderecos["CEP"].ToString()!,
                            Cidade = readerEnderecos["Cidade"].ToString()!
                        };
                        pessoa.Enderecos.Add(endereco);
                    }
                }

                return pessoa;
            }
            catch
            {
                throw;
            }
        }
        public List<Pessoa> ObterPessoas()
        {
            const string query = @"SELECT * FROM Pessoas";
            try
            {
                OpenConnection();
                using var command = CreateCommand(query);
                using var reader = command.ExecuteReader();
                var pessoas = new List<Pessoa>();
                while (reader.Read())
                {
                    var pessoa = new Pessoa
                    {
                        Nome = reader["Nome"].ToString()!,
                        CPF = reader["CPF"].ToString()!,
                        DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                        Email = reader["Email"].ToString()!
                    };
                    pessoa.Id = Convert.ToInt32(reader["Id"]);
                    pessoas.Add(pessoa);
                }
                return pessoas;
            }
            catch
            {
                throw;
            }
        }
        public List<Endereco> ObterEndereco()
        {
            const string query = @"SELECT * FROM Enderecos";
            try
            {
                OpenConnection();
                using var command = CreateCommand(query);
                using var reader = command.ExecuteReader();
                var enderecos = new List<Endereco>();
                while (reader.Read())
                {
                    var endereco = new Endereco
                    {
                        NumeroCasa = reader["NumeroCasa"].ToString()!,
                        Bairro = reader["Bairro"].ToString()!,
                        Logradouro = reader["Logradouro"].ToString()!,
                        UF = reader["UF"].ToString()!,
                        CEP = reader["CEP"].ToString()!,
                        Cidade = reader["Cidade"].ToString()!
                    };
                    enderecos.Add(endereco);
                }
                return enderecos;
            }
            catch
            {
                throw;
            }
        }
       public List<Telefone> ObterTelefone()
        {
            const string query = @"SELECT * FROM Telefones";
            try
            {
                OpenConnection();
                using var command = CreateCommand(query);
                using var reader = command.ExecuteReader();
                var telefones = new List<Telefone>();
                while (reader.Read())
                {
                    var telefone = new Telefone
                    {
                        DDD = reader["DDD"].ToString()!,
                        Numero = reader["Numero"].ToString()!,
                        Tipo = reader["Tipo"].ToString()!
                    };
                    telefones.Add(telefone);
                }
                return telefones;
            }
            catch
            {
                throw;
            }
        }
    }
}
