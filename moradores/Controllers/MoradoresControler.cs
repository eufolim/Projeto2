using Microsoft.AspNetCore.Mvc;
using moradores.DTO;
using moradores.Services;

namespace moradores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradoresController : Controller
    {
        private ServMorador _servMorador;

        public MoradoresController()
        {
            _servMorador = new ServMorador();
        }
        public IActionResult Inserir(CadastraMoradoresDTO cadastraMoradorDto)
        {
            try
            {
                var morador = new Morador(){
                    Nome = cadastraMoradorDto.Nome,
                    CPF = cadastraMoradorDto.CPF,
                    Residencia = cadastraMoradorDto.Residencia
                };

                _servMorador.Inserir(morador);

                var retornoInsercao = new { CodigoMorador = morador.Id };

                return Ok(retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/api/[Controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, MoradoresDTO editarMoradorDto)
        {
            try
            {
                var morador = _servMorador.BuscarMorador(id);

                morador.Nome = editarMoradorDto.Nome;
                morador.CPF = editarMoradorDto.CPF;
                morador.Residencia = editarMoradorDto.Residencia;
                morador.Divida =  editarMoradorDto.Divida;
          
                _servMorador.Editar(morador);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarMorador(int id)
        {
            try
            {
                var morador = _servMorador.BuscarMorador(id);

                return Ok(morador);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/api/[Controller]")]
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var listaMorador = _servMorador.BuscarTodos();

                return Ok(listaMorador);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}