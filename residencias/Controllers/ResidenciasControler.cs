using Microsoft.AspNetCore.Mvc;
using residencias.DTO;
using residencias.DTO.ResidenciaDTO;
using residencias.Services;

namespace Residencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidenciasController : Controller
    {
        private ServResidencia _servResidencia;

        public ResidenciasController()
        {
            _servResidencia = new ServResidencia();
        }
        public IActionResult Inserir(ResidenciaDTO cadastraResidenciaDto)
        {
            try
            {
                var residencia = new Residencia(){
                    Metragen = cadastraResidenciaDto.Metragen,
                    Morador = cadastraResidenciaDto.Morador,
                    Valor = cadastraResidenciaDto.Valor,
                    Numero = cadastraResidenciaDto.Numero
                };

                _servResidencia.Inserir(residencia);

                var retornoInsercao = new { CodigoResidencia = residencia.Id };

                return Ok(retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/api/[Controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, ResidenciaDTO editarResidenciaDto)
        {
            try
            {
                var residencia = _servResidencia.BuscarResidencia(id);

                residencia.Metragen = editarResidenciaDto.Metragen;
                residencia.Morador = editarResidenciaDto.Morador;
                residencia.Valor = editarResidenciaDto.Valor;
                residencia.Numero = editarResidenciaDto.Numero;

                _servResidencia.Editar(residencia);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarResidencia(int id)
        {
            try
            {
                var residencia = _servResidencia.BuscarResidencia(id);

                return Ok(residencia);
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
                var listaResidencia = _servResidencia.BuscarTodos();

                return Ok(listaResidencia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}