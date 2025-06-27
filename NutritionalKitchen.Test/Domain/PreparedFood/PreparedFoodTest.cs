using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.PreparedFood
{
    public class PreparedFoodTest
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var kitchenTaskId = Guid.NewGuid();

            // Act
            var preparedFood = new NutritionalKitchen.Domain.PreparedFood.PreparedFood(kitchenTaskId);

            // Assert
            Assert.NotNull(preparedFood);
            Assert.Equal(kitchenTaskId, preparedFood.IdKitchenTask);
            Assert.NotEqual(Guid.Empty, preparedFood.Id); // Verifica que el ID se genera
        }
    }
}
