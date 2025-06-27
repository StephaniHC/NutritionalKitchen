using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.KitchenTask
{
    public class KitchenTaskTest
    {
        [Fact]
        public void Constructor_ShouldInitializeAllProperties()
        {
            // Arrange
            var description = "Preparar sopa";
            var status = "Pendiente";
            var kitchener = "Chef Juan";
            var preparationDate = new DateTime(2025, 6, 27);

            // Act
            var kitchenTask = new NutritionalKitchen.Domain.KitchenTask.KitchenTask(description, status, kitchener, preparationDate);

            // Assert
            Assert.NotNull(kitchenTask);
            Assert.Equal(description, kitchenTask.Description);
            Assert.Equal(status, kitchenTask.Status);
            Assert.Equal(kitchener, kitchenTask.Kitchener);
            Assert.Equal(preparationDate, kitchenTask.PreparationDate);
            Assert.NotEqual(Guid.Empty, kitchenTask.Id);
        }
    }
}
