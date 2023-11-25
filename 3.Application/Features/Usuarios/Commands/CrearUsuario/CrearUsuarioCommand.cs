using _3.Application.DTOs;
using _4.Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _3.Application.Features.Usuarios.Commands.CrearUsuario
{
    public class CrearUsuarioCommand : IRequest<AuthDTO>
    {
        public string? NombreUsuario { get; set; }

        public string? Pass { get; set; }

    }
}

