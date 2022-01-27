using API.CalculaJuros.CommandHandlers;
using API.CalculaJuros.CommandHandlers.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.CalculaJuros.Configurations
{
    internal static class CommandsConfiguration
    {
        public static IServiceCollection AddCommandsConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICalculoCommandHandler, CalculoCommandHandler>();


            return services;
        }
    }
}
