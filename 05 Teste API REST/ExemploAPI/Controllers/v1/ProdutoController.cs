using ExemploAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        // GET: Endpoint for a list of products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoEntity>>> listarProdutos()
        {
            ProdutoViewModel produtos = new ProdutoViewModel();
            var lista = produtos.listarProdutos();            

            if (lista == null)
                return NoContent();

            return Ok(lista);
        }
    }
}
