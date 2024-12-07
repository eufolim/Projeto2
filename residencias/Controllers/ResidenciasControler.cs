using Microsoft.AspNetCore.Mvc;
using residencias.DTO;
using residencias.Services;

namespace residencias.Controllers
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
                _servResidencia.Inserir(cadastraResidenciaDto);

                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("/api/[Controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, ResidenciaView editarResidenciaDto)
        {
            try
            {
                var residencia = _servResidencia.BuscarResidencia(id);

                residencia.Metragen = editarResidenciaDto.Metragen;
                residencia.CodMorador = editarResidenciaDto.CodMorador;
                residencia.Valor = editarResidenciaDto.Valor;
                residencia.Numero = editarResidenciaDto.Numero;
                residencia.Ativa = editarResidenciaDto.Ativa;

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