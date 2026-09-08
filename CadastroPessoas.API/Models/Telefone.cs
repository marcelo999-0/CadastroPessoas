using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

    }
}



