using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task AddAsync(ContactoCallCenter contacto)
        {
            _context.Set<ContactoCallCenter>().Add(contacto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContactoCallCenter>> GetByEstudianteIdAsync(int estudianteId)
        {
            return await _context.Set<ContactoCallCenter>()
                .Where(c => c.EstudianteId == estudianteId)
                .ToListAsync();
        }
    }
}
