using CadastroPessoas.API.Models;
using CadastroPessoas.Forms.Interface;
using Microsoft.Data.SqlClient;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CadastroPessoas.Forms;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        //SqlConnection cn = new SqlConnection("Data Source=EMG5933\\SQLEXPRESS;Initial Catalog=BancoTeste;User ID=sa;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        //SqlCommand cm = new SqlCommand();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadPessoasAsync();
    }

    private async void btnAdicionar_Click(object sender, EventArgs e)
    {
       using var form2 = new Form2();
        if (form2.ShowDialog() == DialogResult.OK)
        {
            await LoadPessoasAsync();
        }

    
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
                var erro = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Erro ao carregar pessoas.\nStatus: {response.StatusCode}\nDetalhes: {erro}");
            }
        }
    }

    private static readonly HttpClient _httpClient = new HttpClient
    {
      BaseAddress = new Uri("https://localhost:51524/"),
    };


    private async Task LoadPessoasAsync()
    {
       var response = await _httpClient.GetAsync("api/pessoas");
       if (response.IsSuccessStatusCode)
       {
         MessageBox.Show("Lista carregada com sucesso");
         var pessoas = await response.Content.ReadFromJsonAsync<List<Pessoa>>();
         dgvHome.DataSource = pessoas;
         //MessageBox.Show($"Quantidade de pessoas: {pessoas.Count}");
         dgvHome.AutoGenerateColumns = true;
       }
       else
       {
         var erro = await response.Content.ReadAsStringAsync();
         MessageBox.Show("Erro ao carregar pessoas.\nStatus: {response.StatusCode}\nDetalhes: {erro}");
       }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
      if (dgvHome.CurrentRow == null)
      {
        MessageBox.Show("Selecione uma pessoa para editar.");
        return;
      }
        int id = Convert.ToInt32(dgvHome.CurrentRow.Cells["Id"].Value);
        using var client = new HttpClient { BaseAddress = new Uri("https://localhost:51524/") };
        var pessoa = await client.GetFromJsonAsync<Pessoa>($"api/Pessoas/{id}");
   
      if (pessoa == null)
      {
        MessageBox.Show("Não foi possível carregar os dados da pessoa.");
        return;
      }

      using var Form2 = new Form2(pessoa, false);
      if (Form2.ShowDialog() == DialogResult.OK)
      {
      await LoadPessoasAsync();
      }
   
      
    }

    private async void btnConsultar_Click(object sender, EventArgs e)
    {
        if (dgvHome.CurrentRow == null)
        {
            MessageBox.Show("Selecione uma pessoa para consultar");
            return;
        }
         int id = Convert.ToInt32(dgvHome.CurrentRow.Cells["Id"].Value);
         using var client = new HttpClient { BaseAddress = new Uri("https://localhost:51524/") };
         var pessoa = await client.GetFromJsonAsync<Pessoa>($"api/Pessoas/{id}");
       
        if(pessoa == null)
        {
            MessageBox.Show("Não foi possível carregar os dados da pessoa");
            return;
        }

        using var Form2 = new Form2(pessoa, true);
        Form2.ShowDialog();
    }

    private void dgvHome_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
