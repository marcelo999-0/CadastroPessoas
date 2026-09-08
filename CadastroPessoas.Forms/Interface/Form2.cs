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

namespace CadastroPessoas.Forms.Interface
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            SqlConnection cn = new SqlConnection("Data Source = localhost ; integrated security = SSPI ; initial catalog = BancoTeste");
            SqlCommand cm = new SqlCommand();

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

        }
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:51524"),
        };

        private async void btnSalvar_Click_1(object sender, EventArgs e)
        {
            var pessoa = new Pessoa
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
            };

            var endereco = new Endereco
            {
                PessoaId = pessoa.Id,
                Cidade = txtCidade.Text,
                UF = txtUF.Text,
                Rua = txtRua.Text,
                Bairro = txtBairro.Text,
                CEP = txtCEP.Text,
                NumeroCasa = txtNumeroCasa.Text,
                Logradouro = txtLogradouro.Text
            };

            var telefone = new Telefone
            {
                DDD = txtDDD.Text,
                Numero = txtNumeroCasa.Text,
                Tipo = txtTipo.Text
            };

            var result = MessageBox.Show("Deseja realmente salvar o cadastro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

            var response = await _httpClient.PostAsJsonAsync("api/pessoas", pessoa);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Pessoa adicionada com sucesso!");
            }

            else
            {
                MessageBox.Show("Erro ao adicionar pessoa: " + response.ReasonPhrase);
            }
        }
    }
}





