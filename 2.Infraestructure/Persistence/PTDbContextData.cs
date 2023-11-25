using _4.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace _2.Infraestructure.Persistence
{
    public class PTDbContextData : IdentityDbContext<Usuario>
    {
        public static async Task CrearUsuarioInicialAsync(
        UserManager<Usuario> usuarioManager,
        ILoggerFactory loggerFactory

        )
        {
            try
            {
                if (!usuarioManager.Users.Any())
                {
                    Guid idUsuario = Guid.NewGuid();
                    var usuarioAdmin = new Usuario
                    {
                        UserName = "Dorado",
                        Identificador = idUsuario,
                        Id = idUsuario.ToString(),
                        FechaCreacion = DateTime.UtcNow,
                    };

                    var creandoUsuario = await usuarioManager.CreateAsync(usuarioAdmin, "5Mr0ZvgT!!!");

                    if (!creandoUsuario.Succeeded)
                    {
                        var logger = loggerFactory.CreateLogger<PTDbContextData>();
                        logger.LogError($"!!");
                        logger.LogError($"!!");
                        logger.LogError($"!!");
                        logger.LogError($"Error al crear el usuario inicial, errores:");

                        foreach (var item in creandoUsuario.Errors)
                        {
                            logger.LogError($"* {item.Description}");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<PTDbContextData>();
                logger.LogError($"Error al crear el usuario inicial, error: {ex}");

            }
        }
    }
}
