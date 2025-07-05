using NutritionalKitchen.Domain.KitchenTask;
using System;
using Xunit;

namespace NutritionalKitchen.Test.Domain.KitchenTask
{
    public class KitchenTaskFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnKitchenTask_WithCorrectProperties()
        {
            // Arrange
            var factory = new KitchenTaskFactory();
            var kitchener = "Chef Mario";
            var preparationDate = new DateTime(2025, 6, 26);

            // Act
            var result = factory.Create(kitchener, preparationDate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kitchener, result.Kitchener);
            Assert.Equal(preparationDate, result.PreparationDate); 
            Assert.NotEqual(Guid.Empty, result.Id);
        }
    }
}
