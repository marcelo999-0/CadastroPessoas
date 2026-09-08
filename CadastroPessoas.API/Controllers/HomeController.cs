using CadastroPessoas.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.API.Controllers
{
    [ApiController]
    [Route("https://localhost:51524")]
    public class PessoasController(PessoasCadastro pessoasCadastro) : ControllerBase
    {
        private readonly PessoasCadastro _pessoasCadastro = pessoasCadastro;

        [HttpPost]
        public ActionResult CriarPessoa(Models.Pessoa pessoa)
        {

            try
            {
                _pessoasCadastro.CriarPessoa(pessoa);
                return Ok(pessoa);

            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao criar a pessoa.");
            }
        }


        [HttpDelete("{id}")]
        public ActionResult ExcluirPessoa(int id)
        {
            try
            {
                _pessoasCadastro.ExcluirPessoa(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao excluir a pessoa.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Pessoa> ObterPessoa(string id)
        {
            if (!int.TryParse(id, out int cod ))
                return BadRequest("O ID informado não é válido.");

            try
            {
                var pessoa = _pessoasCadastro.ObterPessoa(cod);
                if (pessoa is null)
                    return NotFound();
                return Ok(pessoa);
            }
            catch
            {
               return BadRequest("Ocorreu um erro ao obter a pessoa.");
            }



        }
        
        [HttpGet()]
        public ActionResult<List<Models.Pessoa>> ObterPessoas()
        {
            try
            {
                var pessoas = _pessoasCadastro.ObterPessoas();
                return Ok(pessoas);
            }
            catch
            {
                return Ok(new List<Models.Pessoa>());

            }
        }
    }
}

   