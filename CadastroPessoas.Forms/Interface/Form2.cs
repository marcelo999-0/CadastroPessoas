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
            _pessoaEditando = pessoa;
            PreencherCampos(pessoa);
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
            listEndereco.DataSource = _enderecos;
            listTelefone.DataSource = _telefones;

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

            if (_enderecos.Count(en => en.Principal) != 1)
            {
                MessageBox.Show("Por favor, marque exatamente um endereço como principal.");
                return;
            }

            var pessoa = new Pessoa
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                DataNascimento = dataNascimento,
                Email = txtEmail.Text,
                Enderecos = _enderecos.ToList(),
                Telefones = _telefones.ToList(),
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
        
        }

        private void dgvTelefones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        //private void btnAdicionarTelefone_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtDDD.Text) ||
        //        string.IsNullOrEmpty(txtNumeroTelefone.Text) ||
        //        cbTipo.SelectedItem == null)
        //    {
        //        MessageBox.Show("Preencher DDD, Número e Tipo de telefone");
        //        return;
        //    }

        //    var novoTelefone = new Telefone
        //    {
        //        DDD = txtDDD.Text,
        //        Numero = txtNumeroTelefone.Text,
        //        Tipo = cbTipo.SelectedItem.ToString() ?? ""

        //    };

        //    _telefones.Add(novoTelefone);
        //    LimparCamposTelefone();
        //}


        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogradouro.Text) ||
                string.IsNullOrEmpty(txtCidade.Text) ||
                string.IsNullOrEmpty(txtCep.Text))

            {
                MessageBox.Show("Preencha ao menos Logradouro, Cidade e CEP");
                return;
            }

            bool marcarComoPrincipal = chkPrincipalEndereco.Checked || _enderecos.Count == 0;

            var novoEndereco = new Endereco
            {
                Logradouro = txtLogradouro.Text,
                NumeroCasa = txtNumeroCasa.Text,
                Bairro = txtBairro.Text,
                UF = cbUf.SelectedItem?.ToString(),
                Cidade = txtCidade.Text,
                CEP = txtCep.Text,
                Principal = _enderecos.Count == 0

            };

            _enderecos.Add(novoEndereco);
            LimparCamposEndereco();
        }
        private void LimparCamposEndereco()
        {
            txtLogradouro.Clear();
            txtNumeroCasa.Clear();
            txtBairro.Clear();
            cbUf.SelectedItem = -1;
            txtCidade.Clear();
            txtCep.Clear();
            chkPrincipalEndereco.Checked = false;
        }
        private void PreencherCampos(Pessoa pessoa)
        {
            txtNome.Text = pessoa.Nome;
            txtCPF.Text = pessoa.CPF;
            DataNascimento.Text = pessoa.DataNascimento.ToString("dd/MM/yyyy");

            _enderecos.Clear();
            foreach (var endereco in pessoa.Enderecos)
                _enderecos.Add(endereco);

            _telefones.Clear();
            foreach (var telefone in pessoa.Telefones)
                _telefones.Add(telefone);

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

        private void btnRemoverEndereco_Click(object sender, EventArgs e)
        {
            if(listEndereco.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um endereço para remover.");
                return;
            }

            _enderecos.RemoveAt(listEndereco.SelectedIndex);
        }

        private void btnRemoverTelefone_Click(object sender, EventArgs e)
        {
            if(listTelefone.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um telefone para remover");
                return;
            }
        
            _telefones.RemoveAt(listTelefone.SelectedIndex);
        }

        private void btnAdicionarTelefone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCPF.Text) ||
                string.IsNullOrEmpty(txtNumeroTelefone.Text) ||
                cbTipo.SelectedItem == null)
            {
                MessageBox.Show("Preencha DDD, Número e Tipo de telefone.");
                return;
            }
            
            bool marcarComoPrincipal = chkPrincipalTelefone.Checked || _enderecos.Count == 0;
            
            var novoTelefone = new Telefone
            {
                DDD = txtDDD.Text,
                Numero = txtNumeroTelefone.Text,
                Tipo = cbTipo.SelectedItem.ToString() ?? "",
            };

            _telefones.Add(novoTelefone);
            LimparCamposTelefone();

        }
        private void LimparCamposTelefone()
        {
            txtDDD.Clear();
            txtNumeroTelefone.Clear();
            cbTipo.SelectedItem = -1;
            chkPrincipalEndereco.Checked = false;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }
    }
}






