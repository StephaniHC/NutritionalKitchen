using NutritionalKitchen.Domain.PreparedFood;
using System;
using Xunit;

namespace NutritionalKitchen.Test.Domain.PreparedFood
{
    public class PreparedFoodFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnPreparedFood_WithCorrectProperties()
        {
            // Arrange
            var factory = new PreparedFoodFactory();
            var kitchenTaskId = Guid.NewGuid();
            var recipePreparationId = Guid.NewGuid();
            var recipePreparationDate = new DateTime(2025, 6, 27);
            var status = "Pending";
            var recipe = "Receta Test";
            var detail = "Detalle Test";
            var patientId = Guid.NewGuid();

            // Act
            var result = factory.Create(
                kitchenTaskId,
                recipePreparationId,
                recipePreparationDate,
                status,
                recipe,
                detail,
                patientId
            );

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kitchenTaskId, result.IdKitchenTask);
            Assert.Equal(recipePreparationId, result.IdRecipePreparation);
            Assert.Equal(recipePreparationDate, result.RecipePreparationDate);
            Assert.Equal(status, result.Status);
            Assert.Equal(recipe, result.Recipe);
            Assert.Equal(detail, result.Detail);
            Assert.Equal(patientId, result.PatientId);
            Assert.Null(result.LabelId);
        }
    }
}
