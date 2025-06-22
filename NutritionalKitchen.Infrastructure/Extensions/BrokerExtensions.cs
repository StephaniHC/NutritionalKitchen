using Joseco.Communication.External.RabbitMQ;
using Joseco.Communication.External.RabbitMQ.Services;
using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Integration.Package;
using NutritionalKitchen.Infrastructure.RabbitMQ.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Extensions
{
    public static class BrokerExtensions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            var rabbitMqSettings = serviceProvider.GetRequiredService<RabbitMqSettings>();

            services.AddRabbitMQ(rabbitMqSettings)
                .AddRabbitMqConsumer<Package, PackageConsumer>("nutritionalkitchen-labeled-package");

            return services;
        }
    }
}
