using _3.Application.Contracts.Identity;
using _3.Application.DTOs;
using _4.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _2.Infraestructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        public JWTConfiguracionDTO _jwtSettings { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor, IOptions<JWTConfiguracionDTO> jwtSettings)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSettings = jwtSettings.Value;
        }

        public string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName!),
            new Claim("userId", usuario.Identificador.ToString()),
            new Claim("fechaCreacion", usuario.FechaCreacion.ToString()!)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TiempoEspiracion),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public string ObtenerSesionUsuario()
        {
            var username = _httpContextAccessor.HttpContext!.User?.Claims?
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return username!;
        }

    }
}