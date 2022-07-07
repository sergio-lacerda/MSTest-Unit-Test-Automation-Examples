using ExemploAPI.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExemploAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DescontoController : ControllerBase
    {       
        private readonly ILogger<DescontoController> _logger;

        public DescontoController(ILogger<DescontoController> logger)
        {
            _logger = logger;
        }

        // GET: Endpoint to provide the order percentage discount (if have)
        [HttpGet("percentual-desconto/{valor:float}")]
        public async Task<ActionResult<float>> percentualDesconto([FromRoute] float valor)
        {
            Desconto desc = new Desconto();

            if (desc == null)
                return NoContent();

            return Ok(desc.percentualDesconto(valor));
        }

        // GET: Endpoint to provide the order discount value (if have)
        [HttpGet("valor-desconto/{valor:float}")]
        public async Task<ActionResult<float>> valorDesconto([FromRoute] float valor)
        {
            Desconto desc = new Desconto();

            if (desc == null)
                return NoContent();

            return Ok(desc.valorDesconto(valor));
        }

        // GET: Endpoint to provide the order net value
        [HttpGet("total-com-desconto/{valor:float}")]
        public async Task<ActionResult<float>> totalComDesconto([FromRoute] float valor)
        {
            Desconto desc = new Desconto();

            if (desc == null)
                return NoContent();

            return Ok(desc.valorFinalComDesconto(valor));
        }

        // GET: Endpoint to provide API status information
        [HttpGet("status")]
        public async Task<ActionResult<string>> statusApi()
        {
            return Ok("API em execução e disponível!");
        }        
    }
}
