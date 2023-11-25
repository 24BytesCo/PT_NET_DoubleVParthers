using _3.Application.Contracts.Identity;
using _3.Application.DTOs;
using _4.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace _3.Application.Features.Auth.Commands.Login
{
    public class LoginUsuarioCommand : IRequest<AuthDTO>
    {
        public string? NombreUsuario { get; set; }

        public string? Pass { get; set; }

    }

   
}
