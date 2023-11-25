using _3.Application.Contracts.Identity;
using _3.Application.DTOs;
using _4.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace _3.Application.Features.Usuarios.Commands
{
    public class LoginUsuarioCommand : IRequest<AuthDTO>
    {
        public string? NombreUsuario { get; set; }

        public string? Pass { get; set; }

    }

    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, AuthDTO>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginUsuarioCommandHandler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IAuthService authorizationService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authorizationService;
            _mapper = mapper;
        }

        public async Task<AuthDTO> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioConNombreUsuario = await _userManager.FindByNameAsync(request.NombreUsuario!);

            if (usuarioConNombreUsuario is null)
            {
                throw new Exception("Credenciales incorrectas");
            }

            var esValidoPass = await _signInManager.CheckPasswordSignInAsync(usuarioConNombreUsuario!, request.Pass!, false);

            if (!esValidoPass.Succeeded)
            {
                throw new Exception("Las credenciales son incorrectas");
            }

            return new AuthDTO
            {
                UsuarioId = usuarioConNombreUsuario.Identificador,
                NombreUsuario = usuarioConNombreUsuario.UserName,
                FechaCreacion = usuarioConNombreUsuario.FechaCreacion,
                Token = _authService.CrearToken(usuarioConNombreUsuario)

            };

        }
    }
}
