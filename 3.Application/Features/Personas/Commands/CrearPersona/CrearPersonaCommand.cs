using _3.Application.DTOs;
using _4.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Application.Features.Personas.Commands.CrearPersona
{
    public class CrearPersonaCommand: IRequest<Persona>
    {
        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? TipoIdentificacion { get; set; }
        
        public string? NumeroIdentificacion { get; set; }

        public string? Email { get; set; }

    }
}
