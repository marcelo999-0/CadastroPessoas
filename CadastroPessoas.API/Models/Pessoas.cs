using System.ComponentModel.DataAnnotations;


namespace CadastroPessoas.API.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public List<Telefone> Telefones { get; } = [];
        public List<Endereco> Enderecos { get; } = [];
    }
}