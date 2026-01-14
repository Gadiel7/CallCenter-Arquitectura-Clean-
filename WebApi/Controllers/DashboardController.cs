using Aplication.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardUseCase _useCase;

        public DashboardController(DashboardUseCase useCase)
        {
            _useCase = useCase;
        }

        /// <summary>
        /// Obtiene métricas generales del sistema
        /// </summary>
        [HttpGet("metricas")]
        public async Task<IActionResult> ObtenerMetricas()
        {
            var data = await _useCase.ObtenerMetricas();
            return Ok(data);
        }
    }
}
