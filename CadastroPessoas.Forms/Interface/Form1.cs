using CadastroPessoas.API.Models;
using CadastroPessoas.Forms.Interface;
using Microsoft.Data.SqlClient;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace CadastroPessoas.Forms;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        SqlConnection cn = new SqlConnection("Data Source = localhost ; integrated security = SSPI ; initial catalog = BancoTeste");
        SqlCommand cm = new SqlCommand();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private async void btnAdicionar_Click(object sender, EventArgs e)
    {
        Interface.Form2 form2 = new Interface.Form2();
        form2.ShowDialog();

        await LoadPessoasAsync();
    }

    private async void btnDeletar_Click(object sender, EventArgs e)
    {
        if (dgvHome.SelectedRows.Count == 0)
        {
            MessageBox.Show("Por favor, selecione uma pessoa para deletar.");
            return;
        }

        int id = Convert.ToInt32(dgvHome.SelectedRows[0].Cells["Id"].Value);

        var confirm = MessageBox.Show("Tem certeza que deseja deletar esta pessoa?", "Confirmar Exclusão", MessageBoxButtons.YesNo);

        if (confirm == DialogResult.Yes)
        {
            var response = await _httpClient.DeleteAsync($"api/pessoas/{id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Pessoa deletada com sucesso!");
                await LoadPessoasAsync();
            }
            else
            {
                MessageBox.Show("Erro ao deletar pessoa.");
            }
        }
    }

        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:51524"),
        };

    private async Task LoadPessoasAsync()
    {
        var response = await _httpClient.GetAsync("api/pessoas");
        if (response.IsSuccessStatusCode)
        {
            MessageBox.Show("Lista carregada com sucesso");
            var pessoas = await response.Content.ReadFromJsonAsync<List<Pessoa>>();
            dgvHome.DataSource = pessoas;
        }
        else
        {
            MessageBox.Show("Erro ao carregar pessoas.");
        }
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {

    }

    private void btnConsultar_Click(object sender, EventArgs e)
    {


    }

    private void dgvHome_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
