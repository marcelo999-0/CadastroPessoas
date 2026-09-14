using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace CadastroPessoas.API.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string? DDD { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }
        public bool Principal;
        public override string ToString()
        {
            var marcador = Principal ? " (Principal)" : "";
            return $"({DDD}) {Numero} - {Tipo}{marcador}";
        }
    }
}



