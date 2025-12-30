using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEstudiante
    {
        Task<Estudiante?> GetByIdAsync(int id);
        Task UpdateAsync (Estudiante? estudiante);
        Task<List<Estudiante>> GetAllAsync();
    }
}
