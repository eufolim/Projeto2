using Microsoft.AspNetCore.Mvc;
using taxa.DTO;
using taxa.Services;

namespace taxa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaesController : Controller
    {
        private ServTaxa _servTaxa;

        public TaxaesController()
        {
            _servTaxa = new ServTaxa();
        }
        public IActionResult Inserir(TaxasDTO cadastraTaxaDto)
        {
            try
            {
                var taxa = new Taxa(){
                    
                };

                _servTaxa.Inserir(taxa);

                var retornoInsercao = new { CodigoTaxa = taxa.Id };

                return Ok(retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/api/[Controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, TaxasDTO editarTaxaDto)
        {
            try
            {
                var taxa = _servTaxa.BuscarTaxa(id);

         
          
                _servTaxa.Editar(taxa);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarTaxa(int id)
        {
            try
            {
                var Taxa = _servTaxa.BuscarTaxa(id);

                return Ok(Taxa);
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
                var listaTaxa = _servTaxa.BuscarTodos();

                return Ok(listaTaxa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}