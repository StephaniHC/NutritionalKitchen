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
using System.Reflection;

namespace NutritionalKitchen.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context =>
                    context.UseNpgsql(connectionString));
            services.AddDbContext<DomainDbContext>(context =>
                    context.UseNpgsql(connectionString));

            services.AddScoped<IKitchenTaskRepository, KitchenTaskRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPreparedFoodRepository, PreparedFoodRepository>();
            services.AddScoped<IRecipePreparationRepository, RecipePreparationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAplication()
                .AddSecrets(configuration, environment)
                .AddRabbitMQ();

            return services;
        }
    }
}
