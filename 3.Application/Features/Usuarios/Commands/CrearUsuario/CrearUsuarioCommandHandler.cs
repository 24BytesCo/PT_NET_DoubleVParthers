using _3.Application.Contracts.Identity;
using _3.Application.DTOs;
using _4.Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _3.Application.Features.Usuarios.Commands.CrearUsuario
{
    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, AuthDTO>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IAuthService _authService;

        public CrearUsuarioCommandHandler(UserManager<Usuario> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<AuthDTO> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var existeUsuarioByNombreUsuario = await _userManager.FindByNameAsync(request.NombreUsuario!) is null ? false : true;

                if (existeUsuarioByNombreUsuario)
                {
                    throw new Exception("El nombre de usuario ya existe en la BD");
                }
                Guid idUsuario = Guid.NewGuid();
                var usuarioNuevo = new Usuario
                {
                    Identificador = idUsuario,
                    Id = idUsuario.ToString(),
                    UserName = request.NombreUsuario,
                    FechaCreacion = DateTime.UtcNow
                };

                var creandoUsuario = await _userManager.CreateAsync(usuarioNuevo, request.Pass!);

                if (creandoUsuario.Succeeded)
                {
                    return new AuthDTO
                    {
                        NombreUsuario = usuarioNuevo.UserName,
                        FechaCreacion = usuarioNuevo.FechaCreacion,
                        UsuarioId = usuarioNuevo.Identificador,
                        Token = _authService.CrearToken(usuarioNuevo)
                    };
                }

                var errores = "";
                var letra = 'A';

                foreach (var item in creandoUsuario.Errors)
                {
                    errores += $"{letra}. {item.Description}  |  ";
                    letra++;
                }

                throw new Exception($"{errores.TrimEnd('|', ' ')}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario = {ex}");
                throw new Exception("Error al crear el usuario, error = " + ex.Message);
            }

        }
    }
}

