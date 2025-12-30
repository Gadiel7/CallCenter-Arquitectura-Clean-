using Aplication.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteUseCase _useCase;

        public EstudianteController(EstudianteUseCase useCase)
        {
            _useCase = useCase;
        }

       

        // Call Center / Marketing: consultar estudiante
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var estudiante = await _useCase.ObtenerPorId(id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }
    }
}
