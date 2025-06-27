using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Infrastructure.DomainModel.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.DomainModel
{
    public class PreparedFoodConfigTest
    {
        [Fact]
        public void PreparedFoodConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var config = new PreparedFoodConfig();

            // Act
            config.Configure(modelBuilder.Entity<PreparedFood>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(PreparedFood));
            Assert.NotNull(entityType);
            Assert.Equal("PreparedFood", entityType.GetTableName());

            var idProperty = entityType.FindProperty("Id");
            Assert.NotNull(idProperty);
            Assert.Equal("Id", idProperty.Name);

            var idKitchenTaskProperty = entityType.FindProperty("IdKitchenTask");
            Assert.NotNull(idKitchenTaskProperty);
            Assert.Equal("IdKitchenTask", idKitchenTaskProperty.Name);
        }
    }
}
