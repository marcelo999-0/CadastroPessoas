using CadastroPessoas.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace CadastroPessoas.API.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? NumeroCasa { get; set; }
        public string? Logradouro { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public bool Principal { get; set; }
    
    }
}