using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tienda.Infrastructure.Persistences.Contexts;
using Tienda.Infrastructure.Persistences.Interfaces;
using Tienda.Infrastructure.Persistences.Repositories;

namespace Tienda.Infrastructure.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(TiendaContext).Assembly.FullName;
            var conexion = configuration.GetConnectionString("Tienda");
            var server = ServerVersion.AutoDetect(conexion);
            services.AddDbContext<TiendaContext>(
                options => options.UseMySql(
                    conexion, server,
                    b => b.MigrationsAssembly(assembly)),
                ServiceLifetime.Transient);
            //configuration.GetConnectionString("Tienda"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
