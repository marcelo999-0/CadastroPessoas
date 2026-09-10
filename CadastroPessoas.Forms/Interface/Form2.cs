using CadastroPessoas.API.Models;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CadastroPessoas.Forms.Interface
{
    public partial class Form2 : Form
    {
        private readonly Pessoa? _pessoaEditando;
        private readonly BindingList<Endereco> _enderecos = new();
        private readonly BindingList<Telefone> _telefones = new();

        public Form2(Pessoa pessoa)
        {
            InitializeComponent();
            _pessoaEditando = null;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente cancelar o cadastro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtLogradouro_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvTelefones.DataSource = _telefones;
            dgvEnderecos.DataSource = _enderecos;

        }

        private async void btnSalvar_Click_1(object sender, EventArgs e)
        {
            dgvEnderecos.EndEdit();
            dgvTelefones.EndEdit();

            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                 string.IsNullOrWhiteSpace(txtCPF.Text) ||
                 string.IsNullOrWhiteSpace(DataNascimento.Text) ||
                 string.IsNullOrWhiteSpace(txtEmail.Text))

            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            if (_enderecos.Count == 0)
            {
                MessageBox.Show("Por favor, adicione pelo menos um endereço.");
                return;
            }

            if (!DateTime.TryParseExact(this.DataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida. Por favor, insira uma data válida no formato dd/MM/yyyy.");
                return;
            }

            if (_enderecos.Count(en => en.Principal == true) != 1)
            {
                MessageBox.Show("Por favor, marque exatamente um endereço como principal.");
                return;
            }

            var pessoa = new Pessoa
            {

                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                DataNascimento = DateTime.Parse(DataNascimento.Text),
                Email = txtEmail.Text,
                Enderecos = new List<Endereco>(),
                Telefones = new List<Telefone>(),
            };

            var endereco = new Endereco
            {
                PessoaId = pessoa.Id,
                Cidade = dgvEnderecos.SelectedCells[0].Value?.ToString(),
                UF = dgvEnderecos.SelectedCells[1].Value?.ToString(),
                Bairro = dgvEnderecos.SelectedCells[2].Value?.ToString(),
                CEP = dgvEnderecos.SelectedCells[3].Value?.ToString(),
                NumeroCasa = dgvEnderecos.SelectedCells[4].Value?.ToString(),
                Logradouro = dgvEnderecos.SelectedCells[5].Value?.ToString()
            };

            var telefone = new Telefone
            {
                DDD = dgvTelefones.SelectedCells[0].Value?.ToString(),
                Numero = dgvTelefones.SelectedCells[1].Value?.ToString(),
                Tipo = dgvTelefones.SelectedCells[2].Value?.ToString() ?? ""
            };
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:51524/") };
            HttpResponseMessage response;

            if (_pessoaEditando != null)
            {
                pessoa.Id = _pessoaEditando.Id;
                response = await client.PutAsJsonAsync($"api/pessoas/{pessoa.Id}", pessoa);
            }
            else
            {
                response = await client.PostAsJsonAsync("api/pessoas", pessoa);
            }

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Pessoa salva com sucesso!");
                this.Close();
            }

            else
            {
                var erro = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Erro ao salvar pessoa.\nStatus: {response.StatusCode}\nDetalhes: {erro}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvEnderecos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEnderecos.AutoGenerateColumns = false;
            dgvEnderecos.Columns.Clear();

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cidade",
                HeaderText = "Cidade",
                DataPropertyName = "Cidade"
            });

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UF",
                HeaderText = "UF",
                DataPropertyName = "UF"
            });

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Bairro",
                HeaderText = "Bairro",
                DataPropertyName = "Bairro"
            });

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CEP",
                HeaderText = "CEP",
                DataPropertyName = "CEP"
            });

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroCasa",
                HeaderText = "Número da Casa",
                DataPropertyName = "NumeroCasa"
            });

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Logradouro",
                HeaderText = "Logradouro",
                DataPropertyName = "Logradouro"
            });

            dgvEnderecos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PessoaId",
                HeaderText = "PessoaId",
                DataPropertyName = "PessoaId"
            });
        }

        private void dgvTelefones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTelefones.AutoGenerateColumns = false;
            dgvEnderecos.Columns.Clear();

            dgvTelefones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DDD",
                HeaderText = "DDD",
                DataPropertyName = "DDD"
            });
            dgvTelefones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Numero",
                HeaderText = "Número",
                DataPropertyName = "Numero"
            });
            dgvTelefones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tipo",
                HeaderText = "Tipo",
                DataPropertyName = "Tipo"
            });
            dgvTelefones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PessoaId",
                HeaderText = "PessoaId",
                DataPropertyName = "PessoaId"
            });
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLogradouro.Text) ||
                string.IsNullOrWhiteSpace(txtCidade.Text) ||
                string.IsNullOrWhiteSpace(txtCep.Text))
            {
                MessageBox.Show("Preencha ao menos Logradouro, Cidade e CEP do endereço.");
                return;
            }

            _enderecos.Add(new Endereco
            {
                NumeroCasa = txtNumeroCasa.Text,
                Bairro = txtBairro.Text,
                Logradouro = txtLogradouro.Text,
                Cidade = txtCidade.Text,
                UF = cbUf.SelectedItem?.ToString() ?? "",
                CEP = txtCep.Text,
                Principal = chkPrincipal.Checked
            });

            LimparCamposNovoEndereco();
        }

        private void LimparCamposNovoEndereco()
        {
            txtLogradouro.Clear();
            txtNumeroCasa.Clear();
            txtBairro.Clear();
            txtLogradouro.Clear();
            txtCidade.Clear();
            cbUf.SelectedIndex = -1;
            txtCep.Clear();
            chkPrincipal.Checked = false;
        }

        private void listEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listTelefone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNumeroCasa_Click(object sender, EventArgs e)
        {

        }
    }
}
}





