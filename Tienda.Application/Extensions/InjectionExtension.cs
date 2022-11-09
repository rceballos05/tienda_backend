using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tienda.Application.Interfaces;
using Tienda.Application.Services;

namespace Tienda.Application.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();

            return services;

        }
    }
}
