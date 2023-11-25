using _4.Domain;

namespace _3.Application.Contracts.Identity
{
    public interface IAuthService
    {
        string ObtenerSesionUsuario();

        string CrearToken(Usuario usuario);

    }
}
