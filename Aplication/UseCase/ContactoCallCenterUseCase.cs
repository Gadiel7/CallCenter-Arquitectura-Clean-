using Aplication.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCase
{
    public class ContactoCallCenterUseCase
    {
        private readonly IContactoCallCenter _contactoCallCenter;

        public ContactoCallCenterUseCase(IContactoCallCenter contactoCallCenter)
        {
            _contactoCallCenter = contactoCallCenter;
        }

        public async Task RegistrarContacto(ContactoCallCenterDto dto)
        {
            var contacto = new ContactoCallCenter
            {
                EstudianteId = dto.EstudianteId,
                FechaContacto = DateTime.Now,
                Estado = dto.Estado
            };

            // ✅ MÉTODO CORRECTO
            await _contactoCallCenter.RegistrarContactoAsync(contacto);
        }

        public async Task<List<ContactoCallCenter>> ObtenerPorEstudiante(int estudianteId)
        {
            return await _contactoCallCenter.GetByEstudianteIdAsync(estudianteId);
        }
        public async Task<List<ContactoCallCenter>> ObtenerTodos()
        {
            return await _contactoCallCenter.GetAllAsync();
        }

    }
}
