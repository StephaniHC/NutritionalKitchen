using NutritionalKitchen.Domain.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Label
{
    public class LabelFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnLabel_WithCorrectProperties()
        {
            // Arrange
            var factory = new LabelFactory();
            var productionDate = new DateTime(2025, 6, 26);
            var expirationDate = productionDate.AddDays(7);
            var deliberyDate = productionDate.AddDays(1);
            var detail = "Sin gluten";
            var address = "Calle Falsa 123";
            var contractId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var deliberyId = Guid.NewGuid();
            var status = true;

            // Act
            var result = factory.Create(productionDate, expirationDate, deliberyDate, detail, address, contractId, patientId, deliberyId, status);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productionDate, result.ProductionDate);
            Assert.Equal(expirationDate, result.ExpirationDate);
            Assert.Equal(deliberyDate, result.DeliberyDate);
            Assert.Equal(detail, result.Detail);
            Assert.Equal(address, result.Address);
            Assert.Equal(contractId, result.ContractId);
            Assert.Equal(patientId, result.PatientId);
        }
    }
}
