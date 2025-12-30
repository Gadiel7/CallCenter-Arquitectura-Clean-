using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class EstudianteUseCase
    {
        private readonly IEstudiante _estudiante;
        private readonly IMapper _mapper;

        public EstudianteUseCase(
            IEstudiante estudiante,
            IMapper mapper)
        {
            _estudiante = estudiante;
            _mapper = mapper;
        }

        public async Task<EstudianteDto?> ObtenerPorId(int id)
        {
            var entidad = await _estudiante.GetByIdAsync(id);
            if (entidad == null)
                return null;

            return _mapper.Map<EstudianteDto>(entidad);
        }

        public async Task<bool> ActualizarCelular(int id, string celular)
        {
            var entidad = await _estudiante.GetByIdAsync(id);
            if (entidad == null)
                return false;

            entidad.Celular = celular;
            await _estudiante.UpdateAsync(entidad);

            return true;
        }
    }
}
