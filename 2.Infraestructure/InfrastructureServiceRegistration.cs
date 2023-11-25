using _2.Infraestructure.Repositories;
using _2.Infraestructure.Services.Auth;
using _3.Application.Contracts.Identity;
using _3.Application.DTOs;
using _3.Application.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _2.Infraestructure
{

    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                                    IConfiguration configuration
        )
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddTransient<IAuthService, AuthService>();

            services.Configure<JWTConfiguracionDTO>(configuration.GetSection("JwtSettings"));

            return services;
        }

    }
}
