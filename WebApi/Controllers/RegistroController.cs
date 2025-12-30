using Aplication.DTOs;
using Aplication.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Módulo de Registro: actualización de datos de contacto
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly EstudianteUseCase _useCase;

        public RegistroController(EstudianteUseCase useCase)
        {
            _useCase = useCase;
        }

        /// <summary>
        /// Actualiza el número de celular de un estudiante
        /// </summary>
        
        [HttpPut("{id}/celular")]
        public async Task<IActionResult> ActualizarCelular(
            int id,
            [FromBody] ActualizarCelularDto dto)
        {
            var ok = await _useCase.ActualizarCelular(id, dto.Celular);

            if (!ok)
                return NotFound("Estudiante no encontrado");

            return Ok("Celular actualizado correctamente");
        }
    }
}
