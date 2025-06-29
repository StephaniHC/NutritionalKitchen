using Joseco.Outbox.EFCore;
using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Domain.RecipePreparation;
using NutritionalKitchen.Infrastructure.DomainModel;
using NutritionalKitchen.Infrastructure.Repositories;
using NutritionalKitchen.Infrastructure.StoredModel;
using NutritionalKitchen.Infrastructure.Extensions;
using System.Reflection;
using NutritionalKitchen.Application;
using System.Diagnostics.CodeAnalysis;

namespace NutritionalKitchen.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, string serviceName)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context =>
                    context.UseNpgsql(connectionString));
            services.AddDbContext<DomainDbContext>(context =>
                    context.UseNpgsql(connectionString)); 

            services.AddScoped<IKitchenTaskRepository, KitchenTaskRepository>()
                    .AddScoped<ILabelRepository, LabelRepository>()
                    .AddScoped<IPackageRepository, PackageRepository>()
                    .AddScoped<IPreparedFoodRepository, PreparedFoodRepository>()
                    .AddScoped<IRecipePreparationRepository, RecipePreparationRepository>()
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddOutbox<DomainEvent>();

            services.AddAplication()
                .AddSecrets(configuration, environment)
                .AddRabbitMQ();

            return services;
        }
    }
}
