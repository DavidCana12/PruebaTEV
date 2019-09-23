using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaTEV.Context;

namespace PruebaTEV.Core
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterProjectCoreUserEfDataAccess(this IServiceCollection services, string conexion)
        {
            //Add EF DbContexts
            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(conexion);
            }, contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            //Add implemented repository classes
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

    }
}
