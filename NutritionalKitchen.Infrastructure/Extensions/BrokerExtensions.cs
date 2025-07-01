using Joseco.Communication.External.RabbitMQ;
using Joseco.Communication.External.RabbitMQ.Services;
using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Infrastructure.RabbitMQ.Consumers;
using NutritionalKitchen.Integration.Package;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using NutritionalKitchen.Integration.Labeled;

namespace NutritionalKitchen.Infrastructure.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class BrokerExtensions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            var rabbitMqSettings = serviceProvider.GetRequiredService<RabbitMqSettings>();

            services.AddRabbitMQ(rabbitMqSettings)
                .AddRabbitMqConsumer<Labeled, LabeledConsumer>("CalendarCreatedMessage")
                .AddRabbitMqConsumer<DeliberyUpdate, LabeledUpdateConsumer>("DeliveryDayUpdatedMessage")
                .AddRabbitMqConsumer<DeliberyUpdate, LabeledDesactive>("DeliveryDayDeletedMessage")
                .AddRabbitMqConsumer<Labeled, LabeledConsumer>("RecipeCreated")
                .AddRabbitMqConsumer<Package, PackageConsumer>("nutritionalkitchen-labeled-package");

            return services;
        }
    }
}
