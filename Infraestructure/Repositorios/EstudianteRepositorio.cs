using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositorios
{
    public class EstudianteRepositorio : IEstudiante
    {
        private readonly AppDbContext _context;

        public EstudianteRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _context.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync (Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Estudiante>> GetAllAsync()
        {
            return await _context.Estudiantes
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
