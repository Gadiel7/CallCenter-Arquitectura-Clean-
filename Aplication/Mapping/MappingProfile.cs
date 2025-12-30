using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() 
        {
            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<EstudianteDto, Estudiante>();

            CreateMap<ContactoCallCenter, ContactoCallCenterDto>();
            CreateMap<ContactoCallCenterDto, ContactoCallCenter>();

            CreateMap<Estudiante, EstudianteMarketingDto>();

        }

    }
}
