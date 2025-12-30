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
    public class ContactoCallCenterUseCase
    {
        private readonly IContactoCallCenter _repositorio;
        private readonly IMapper _mapper;

        public ContactoCallCenterUseCase(
            IContactoCallCenter repositorio,
            IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task RegistrarContacto(ContactoCallCenterDto dto)
        {
            var entidad = _mapper.Map<ContactoCallCenter>(dto);
            await _repositorio.AddAsync(entidad);
        }

        public async Task<List<ContactoCallCenterDto>> ObtenerPorEstudiante(int estudianteId)
        {
            var contactos = await _repositorio.GetByEstudianteIdAsync(estudianteId);
            return _mapper.Map<List<ContactoCallCenterDto>>(contactos);
        }
    }
}
