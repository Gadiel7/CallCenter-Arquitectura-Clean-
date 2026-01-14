using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class MarketingUseCase
    {
        private readonly IEstudiante _estudianteRepositorio;
        private readonly IMapper _mapper;

        public MarketingUseCase(
            IEstudiante estudianteRepositorio,
            IMapper mapper)
        {
            _estudianteRepositorio = estudianteRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EstudianteMarketingDto>> ObtenerContactosMarketing()
        {
            var estudiantes = await _estudianteRepositorio.GetAllAsync();
            return _mapper.Map<List<EstudianteMarketingDto>>(estudiantes);
        }
       
    }
}
