using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContactoCallCenter
    {
        Task<List<ContactoCallCenter>> GetAllAsync();

        Task<List<ContactoCallCenter>> GetByEstudianteIdAsync(int estudianteId);

        Task RegistrarContactoAsync(ContactoCallCenter contacto);
    
    }
}
