using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.CalculaJuros.Configurations
{
    internal static class HTTPClientConfiguration
    {
        public static IServiceCollection AddApiHTTPClientConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            services.AddHttpClient("API-Juros", c =>
            {
                c.BaseAddress = new Uri(String.Concat(configuration.GetSection("ApiBaseUrl:ApiJuros").Value, "/"));
            });


            return services;
        }
    }
}
