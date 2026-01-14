using Aplication.DTOs;
using Aplication.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    /// Módulo de Call Center: consulta y seguimiento de contactos
    
    [ApiController]
    [Route("api/[controller]")]
    public class CallCenterController : ControllerBase
    {
        private readonly EstudianteUseCase _estudianteUseCase;
        private readonly ContactoCallCenterUseCase _contactoUseCase;

        public CallCenterController(
            EstudianteUseCase estudianteUseCase,
            ContactoCallCenterUseCase contactoUseCase)
        {
            _estudianteUseCase = estudianteUseCase;
            _contactoUseCase = contactoUseCase;
        }

        
        /// Obtiene los datos de un estudiante para contacto
        
        [HttpGet("estudiantes/{id}")]
        public async Task<IActionResult> ObtenerEstudiante(int id)
        {
            var estudiante = await _estudianteUseCase.ObtenerPorId(id);

            if (estudiante == null)
                return NotFound("Estudiante no encontrado");

            return Ok(estudiante);
        }

        
        /// Registra un contacto realizado por el Call Center
        
        [HttpPost("contacto")]
        public async Task<IActionResult> RegistrarContacto(
            [FromBody] ContactoCallCenterDto dto)
        {
            await _contactoUseCase.RegistrarContacto(dto);
            return Ok("Contacto registrado correctamente");
        }
        


        /// Obtiene el historial de contactos de un estudiante
        
        [HttpGet("contactos/{estudianteId}")]
        public async Task<IActionResult> ObtenerContactos(int estudianteId)
        {
            var contactos = await _contactoUseCase.ObtenerPorEstudiante(estudianteId);
            return Ok(contactos);
        }
    }
}
