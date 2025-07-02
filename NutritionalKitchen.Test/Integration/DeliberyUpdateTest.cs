using NutritionalKitchen.Integration.Labeled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Integration
{
    public class DeliberyUpdateTest
    {
        [Fact]
        public void Constructor_ShouldAssign_AllPropertiesCorrectly()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var deliveryDayId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var street = "Main Street";
            var number = 42;
            var ocurredOn = new DateTime(2025, 1, 1);
            var correlationId = "abc-123";
            var source = "TestSource";

            // Act
            var message = new DeliberyUpdate(
                contractId,
                deliveryDayId,
                id,
                street,
                number,
                ocurredOn,
                correlationId,
                source
            );

            // Assert
            Assert.Equal(contractId, message.ContractId);
            Assert.Equal(deliveryDayId, message.DeliveryDayId);
            Assert.Equal(id, message.Id);
            Assert.Equal(street, message.Street);
            Assert.Equal(number, message.Number);
            Assert.Equal(ocurredOn, message.OcurredOn);
            Assert.Equal(correlationId, message.CorrelationId);
            Assert.Equal(source, message.Source);
        }

        [Fact]
        public void Constructor_ShouldSetUtcNow_WhenOcurredOnIsNull()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var deliveryDayId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var before = DateTime.UtcNow;

            // Act
            var message = new DeliberyUpdate(contractId, deliveryDayId, id);

            var after = DateTime.UtcNow;

            // Assert
            Assert.True(message.OcurredOn >= before && message.OcurredOn <= after);
        }
    }
}