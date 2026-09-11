using CadastroPessoas.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CadastroPessoas.API.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }
        public string? Bairro { get; set; }
        public string? NumeroCasa { get; set; }
        public string? Logradouro { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public bool Principal { get; set; }

        public override string ToString()
        {
            var marcador = Principal ? " (Principal)" : "";
            return $"{Logradouro}, {NumeroCasa} - {Bairro}, {Cidade}/{UF}{marcador}";
        }
    }
}
