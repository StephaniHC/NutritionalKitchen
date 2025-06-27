using NutritionalKitchen.Domain.KitchenTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.KitchenTask
{
    public class KitchenTaskFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnKitchenTask_WithCorrectProperties()
        {
            // Arrange
            var factory = new KitchenTaskFactory();
            var description = "Prepare soup";
            var status = "Pending";
            var kitchener = "Chef Mario";
            var date = new DateTime(2025, 6, 26);

            // Act
            var result = factory.Create(description, status, kitchener, date);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(description, result.Description);
            Assert.Equal(status, result.Status);
            Assert.Equal(kitchener, result.Kitchener);
            Assert.Equal(date, result.PreparationDate);
        }
    }
}
