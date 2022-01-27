using Infra.Services;
using Infra.Services.Remotes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.CalculaJuros.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IJurosRemoteService, JurosRemoteService>();

            return services;
        }
    }
}
