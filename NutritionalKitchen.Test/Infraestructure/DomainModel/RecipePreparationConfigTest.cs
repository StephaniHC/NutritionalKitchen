using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NutritionalKitchen.Domain.RecipePreparation;
using NutritionalKitchen.Infrastructure.DomainModel.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.DomainModel
{
    public class RecipePreparationConfigTest
    {
        [Fact]
        public void RecipePreparationConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var config = new RecipePreparationConfig();

            // Act
            config.Configure(modelBuilder.Entity<RecipePreparation>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(RecipePreparation));
            Assert.NotNull(entityType);
            Assert.Equal("RecipePreparation", entityType.GetTableName());

            var idProperty = entityType.FindProperty("Id");
            Assert.NotNull(idProperty);
            Assert.Equal("Id", idProperty.Name);

            var recipeNameProperty = entityType.FindProperty("RecipeName");
            Assert.NotNull(recipeNameProperty);
            Assert.Equal("RecipeName", recipeNameProperty.Name);

            var detailProperty = entityType.FindProperty("Detail");
            Assert.NotNull(detailProperty);
            Assert.Equal("Detail", detailProperty.Name);

            var preparationDateProperty = entityType.FindProperty("PreparationDate");
            Assert.NotNull(preparationDateProperty);
            Assert.Equal("PreparationDate", preparationDateProperty.Name);

            var patientIdProperty = entityType.FindProperty("PatientId");
            Assert.NotNull(patientIdProperty);
            Assert.Equal("PatientId", patientIdProperty.Name);
        }
    }
}
