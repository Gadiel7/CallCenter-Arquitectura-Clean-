using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositorios
{
    public class ContactoCallCenterRepository : IContactoCallCenter
    {
        private readonly AppDbContext _context;

        public ContactoCallCenterRepository(AppDbContext context)
        {
            _context = context;
        }

        // ✅ NUEVO: requerido por el Dashboard
        public async Task<List<ContactoCallCenter>> GetAllAsync()
        {
            return await _context.ContactosCallCenter.ToListAsync();
        }

        public async Task<List<ContactoCallCenter>> GetByEstudianteIdAsync(int estudianteId)
        {
            return await _context.ContactosCallCenter
                .Where(c => c.EstudianteId == estudianteId)
                .OrderByDescending(c => c.FechaContacto)
                .ToListAsync();
        }

        public async Task RegistrarContactoAsync(ContactoCallCenter contacto)
        {
            _context.ContactosCallCenter.Add(contacto);
            await _context.SaveChangesAsync();
        }
        
    }
}
