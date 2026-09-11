using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace CadastroPessoas.API.Models
{
    public class Telefone
    {
        [Key]
        public int Id;
        public int PessoaId;
        public string? DDD;
        public string? Numero;
        public string? Tipo;
        public bool Principal {  get; set; }

        public override string ToString()
        {
            var marcador = Principal ? " (Principal)" : "";
            return $"({DDD}) {Numero} - {Tipo}{marcador}";
        }
        
    }
}



