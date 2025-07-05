using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Label
{
    public class LabelTest
    {
        [Fact]
        public void Update_ShouldModifyAddress()
        {
            // Arrange
            var id = Guid.NewGuid();
            var label = new NutritionalKitchen.Domain.Label.Label(
                id,
                DateTime.Now,
                DateTime.Now.AddDays(10),
                DateTime.Now.AddDays(1),
                "Detalle",
                "Dirección inicial",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                true
            );
            var newAddress = "Nueva dirección 123";

            // Act
            label.Update(newAddress);

            // Assert
            Assert.Equal(newAddress, label.Address);
        }

    }
}
