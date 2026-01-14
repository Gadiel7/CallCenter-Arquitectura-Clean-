using Aplication.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Controllers
{
    /// <summary>
    /// Módulo de Marketing: análisis y exportación de contactos
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

        /// <summary>
        /// Devuelve los contactos para mostrar en pantalla (JSON)
        /// </summary>
        [HttpGet("contactos")]
        public async Task<IActionResult> ObtenerContactos()
        {
            var data = await _useCase.ObtenerContactosMarketing();
            return Ok(data);
        }

        /// <summary>
        /// Exporta los contactos en formato CSV (Excel)
        /// </summary>
        [HttpGet("exportar")]
        public async Task<IActionResult> ExportarContactos()
        {
            var contactos = await _useCase.ObtenerContactosMarketing();

            var csv = new StringBuilder();
            csv.AppendLine("Id,Nombre,Celular");

            foreach (var c in contactos)
            {
                csv.AppendLine($"{c.Id},{c.Nombre},{c.Celular}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());

            return File(
                bytes,
                "text/csv",
                "contactos_marketing.csv"
            );
        }
    }
}
