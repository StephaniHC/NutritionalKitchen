using Joseco.Communication.External.RabbitMQ.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Extensions
{
    public static class SecretExtensions
    {
        private const string RabbitMqSettingsSecretName = "RabbitMqSettings";

        public static IServiceCollection AddSecrets(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            bool useSecretManager = configuration.GetValue<bool>("UseSecretManager", false);
            if (environment.IsDevelopment() && !useSecretManager)
            {
                configuration
                    .LoadAndRegister<RabbitMqSettings>(services, RabbitMqSettingsSecretName);

                return services;
            }
            return services;
        }

        private static IConfiguration LoadAndRegister<T>(this IConfiguration configuration, IServiceCollection services,
        string secretName) where T : class, new()
        {
            T secret = Activator.CreateInstance<T>();
            configuration.Bind(secretName, secret);
            services.AddSingleton<T>(secret);
            return configuration;
        }
    }
}
