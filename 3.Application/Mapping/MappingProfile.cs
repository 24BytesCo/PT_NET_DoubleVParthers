using _3.Application.DTOs;
using _4.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(p => p.Identificador, x => x.MapFrom(t => t.Identificador))
                .ForMember(p => p.NombreUsuario, x => x.MapFrom(t => t.UserName))
                .ForMember(p => p.FechaCreacion, x => x.MapFrom(t => t.FechaCreacion));
                


        }
    }
}
