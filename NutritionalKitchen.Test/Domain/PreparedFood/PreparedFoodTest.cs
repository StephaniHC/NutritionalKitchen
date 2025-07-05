using System;
using Xunit;

namespace NutritionalKitchen.Test.Domain.PreparedFood
{
    public class PreparedFoodTest
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var kitchenTaskId = Guid.NewGuid();
            var recipePreparationId = Guid.NewGuid();
            var recipePreparationDate = new DateTime(2025, 6, 27);
            var status = "Pending";
            var recipe = "Receta A";
            var detail = "Detalle de la receta";
            var patientId = Guid.NewGuid();
            Guid? labelId = Guid.NewGuid();

            // Act
            var preparedFood = new NutritionalKitchen.Domain.PreparedFood.PreparedFood(
                kitchenTaskId,
                recipePreparationId,
                recipePreparationDate,
                status,
                recipe,
                detail,
                patientId,
                labelId
            );

            // Assert
            Assert.NotNull(preparedFood);
            Assert.Equal(kitchenTaskId, preparedFood.IdKitchenTask);
            Assert.Equal(recipePreparationId, preparedFood.IdRecipePreparation);
            Assert.Equal(recipePreparationDate, preparedFood.RecipePreparationDate);
            Assert.Equal(status, preparedFood.Status);
            Assert.Equal(recipe, preparedFood.Recipe);
            Assert.Equal(detail, preparedFood.Detail);
            Assert.Equal(patientId, preparedFood.PatientId);
            Assert.Equal(labelId, preparedFood.LabelId);
            Assert.NotEqual(Guid.Empty, preparedFood.Id); // Verifica que el ID se genera
        }

        [Fact]
        public void UpdateStatus_ShouldChangeStatusProperty()
        {
            // Arrange
            var preparedFood = new NutritionalKitchen.Domain.PreparedFood.PreparedFood(
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now,
                "Pending",
                "Receta B",
                "Detalle",
                Guid.NewGuid(),
                null
            );

            var newStatus = "Completed";

            // Act
            preparedFood.UpdateStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, preparedFood.Status);
        }
    }
}
