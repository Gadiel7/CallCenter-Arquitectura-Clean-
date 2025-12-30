using Aplication.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Módulo de Marketing: análisis y exportación
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingController : ControllerBase
    {
        private readonly MarketingUseCase _useCase;

        public MarketingController(MarketingUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("contactos")]
        public async Task<IActionResult> ObtenerContactos()
        {
            var data = await _useCase.ObtenerContactosMarketing();
            return Ok(data);
        }
    }
}
