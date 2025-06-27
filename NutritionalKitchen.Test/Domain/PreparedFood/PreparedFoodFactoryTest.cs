using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.PreparedFood
{
    public class PreparedFoodFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnPreparedFood_WithCorrectIdKitchenTask()
        {
            // Arrange
            var factory = new PreparedFoodFactory();
            var kitchenTaskId = Guid.NewGuid();

            // Act
            var result = factory.Create(kitchenTaskId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kitchenTaskId, result.IdKitchenTask);
        }
    }
}
