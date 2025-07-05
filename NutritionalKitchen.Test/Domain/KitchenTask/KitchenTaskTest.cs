using System;
using Xunit;
using NutritionalKitchen.Domain.KitchenTask;

namespace NutritionalKitchen.Test.Domain.KitchenTask
{
    public class KitchenTaskTest
    {
        [Fact]
        public void Constructor_ShouldInitializeAllProperties()
        {
            // Arrange
            var kitchener = "Chef Juan";
            var preparationDate = new DateTime(2025, 6, 27);

            // Act
            var kitchenTask = new NutritionalKitchen.Domain.KitchenTask.KitchenTask(kitchener, preparationDate);

            // Assert
            Assert.NotNull(kitchenTask);
            Assert.Equal(kitchener, kitchenTask.Kitchener);
            Assert.Equal(preparationDate, kitchenTask.PreparationDate);
            Assert.NotEqual(Guid.Empty, kitchenTask.Id);
        }
    }
}
