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
        Task AddAsync(ContactoCallCenter contacto);
        Task<List<ContactoCallCenter>> GetByEstudianteIdAsync(int estudianteId);
    }
}
