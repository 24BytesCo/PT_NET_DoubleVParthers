using _3.Application.Contracts.Identity;
using _3.Application.DTOs;
using _3.Application.Features.Usuarios.Commands.CrearUsuario;
using _3.Application.Persistence;
using _4.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Application.Features.Personas.Commands.CrearPersona
{
    public class CrearPersonaCommandHandler : IRequestHandler<CrearPersonaCommand, Persona>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CrearPersonaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Persona> Handle(CrearPersonaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var personaConNumeroIdentificacionYTipo = await _unitOfWork.Repository<Persona>().GetEntityAsync(x=> x.TipoIdentificacion == request.TipoIdentificacion && x.NumeroIdentificacion == request.NumeroIdentificacion);

                if (personaConNumeroIdentificacionYTipo != null)
                {
                    throw new Exception("Ya existe una persona con ese tipo de identificaciòn y nùmero.");
                }

                var nuevaPersona = new Persona
                {
                    Identificador = Guid.NewGuid(),
                    NumeroIdentificacion = request.NumeroIdentificacion,
                    TipoIdentificacion = request.TipoIdentificacion,
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Email = request.Email,
                    FechaCreacion = DateTime.UtcNow
                };


                await _unitOfWork.Repository<Persona>().AddAsync(nuevaPersona);

                return nuevaPersona;

            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un fallo al crear persona, error: {ex.Message}");
            }
        }
    }
}
