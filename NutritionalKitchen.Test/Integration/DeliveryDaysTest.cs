using NutritionalKitchen.Integration.Labeled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Integration
{
    public class DeliveryDaysTest
    {
        [Fact]
        public void Constructor_ShouldAssign_AllPropertiesCorrectly()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var date = new DateTime(2025, 7, 2);
            var street = "Av. Siempre Viva";
            var number = 123;

            // Act
            var delivery = new DeliveryDays(contractId, id, date, street, number);

            // Assert
            Assert.Equal(contractId, delivery.ContractId);
            Assert.Equal(id, delivery.Id);
            Assert.Equal(date, delivery.Date);
            Assert.Equal(street, delivery.Street);
            Assert.Equal(number, delivery.Number);
        }

        [Fact]
        public void Constructor_ShouldSetUtcNow_WhenDateIsNull()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var before = DateTime.UtcNow;

            // Act
            var delivery = new DeliveryDays(contractId, id);

            var after = DateTime.UtcNow;

            // Assert
            Assert.True(delivery.Date >= before && delivery.Date <= after);
        }
    }
}
