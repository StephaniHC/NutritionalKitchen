using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Domain.RecipePreparation;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace NutritionalKitchen.Application
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    { 
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IKitchenTaskFactory, KitchenTaskFactory>();
            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IPackageFactory, PackageFactory>();
            services.AddSingleton<IPreparedFoodFactory, PreparedFoodFactory>();
            services.AddSingleton<IRecipePreparationFactory, RecipePreparationFactory>(); 
            services.AddSingleton<IRecipeFactory, RecipeFactory>(); 
             
            return services;
        }
    }
}
