using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Domain.RecipePreparation;
using NutritionalKitchen.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application
{
    public class ExtensionsTest
    {
        [Fact]
        public void AddAplication_ShouldRegisterServicesCorrectly()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddAplication();
            var serviceProvider = services.BuildServiceProvider();

            // Assert: verificar fábricas registradas
            Assert.NotNull(serviceProvider.GetService<IKitchenTaskFactory>());
            Assert.NotNull(serviceProvider.GetService<ILabelFactory>());
            Assert.NotNull(serviceProvider.GetService<IPackageFactory>());
            Assert.NotNull(serviceProvider.GetService<IPreparedFoodFactory>());
            Assert.NotNull(serviceProvider.GetService<IRecipePreparationFactory>());

            // Assert: verificar MediatR
            var mediator = serviceProvider.GetService<IMediator>();
            Assert.NotNull(mediator);
        }
    }
}
