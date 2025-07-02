using NutritionalKitchen.Integration.Labeled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Integration
{
    public class LabeledTest
    {
        [Fact]
        public void Constructor_ShouldAssign_AllPropertiesCorrectly()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var startDate = new DateTime(2025, 7, 2, 10, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 7, 3, 18, 0, 0, DateTimeKind.Utc);
            var deliveryDays = new List<DeliveryDays>
            {
                new DeliveryDays(contractId, Guid.NewGuid(), DateTime.UtcNow, "Calle A", 1),
                new DeliveryDays(contractId, Guid.NewGuid(), DateTime.UtcNow, "Calle B", 2)
            };
            var ocurredOn = new DateTime(2025, 7, 1, 12, 30, 0, DateTimeKind.Utc);
            var correlationId = "corr-123";
            var source = "MySource";

            // Act
            var msg = new Labeled(
                contractId,
                patientId,
                id,
                startDate,
                endDate,
                deliveryDays,
                ocurredOn,
                correlationId,
                source
            );

            // Assert
            Assert.Equal(contractId, msg.ContractId);
            Assert.Equal(patientId, msg.PatientId);
            Assert.Equal(id, msg.Id);
            Assert.Equal(startDate, msg.StartDate);
            Assert.Equal(endDate, msg.EndDate);
            Assert.Same(deliveryDays, msg.DeliveryDays);
            Assert.Equal(ocurredOn, msg.OcurredOn);
            Assert.Equal(correlationId, msg.CorrelationId);
            Assert.Equal(source, msg.Source);
        }

        [Fact]
        public void Constructor_ShouldInitialize_Defaults_WhenOptionalArgsMissing()
        {
            // Arrange
            var contractId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var id = Guid.NewGuid();

            var before = DateTime.UtcNow;

            // Act
            var msg = new Labeled(contractId, patientId, id);

            var after = DateTime.UtcNow;

            // Assert: fechas entre before y after
            Assert.True(msg.StartDate >= before && msg.StartDate <= after);
            Assert.True(msg.EndDate >= before && msg.EndDate <= after);
            Assert.True(msg.OcurredOn >= before && msg.OcurredOn <= after);

            // Assert: lista por defecto vacía
            Assert.NotNull(msg.DeliveryDays);
            Assert.Empty(msg.DeliveryDays);

            // Propiedades heredadas
            Assert.Null(msg.CorrelationId);
            Assert.Null(msg.Source);
        }
    }
}
