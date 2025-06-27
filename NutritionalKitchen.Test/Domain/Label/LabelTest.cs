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
        public void Constructor_ShouldInitializeAllProperties()
        {
            // Arrange
            var productionDate = new DateTime(2025, 6, 27);
            var expirationDate = productionDate.AddDays(10);
            var deliberyDate = productionDate.AddDays(1);
            var detail = "Etiqueta especial";
            var address = "Av. Siempre Viva 742";
            var contractId = Guid.NewGuid();
            var patientId = Guid.NewGuid();

            // Act
            var label = new NutritionalKitchen.Domain.Label.Label(productionDate, expirationDate, deliberyDate, detail, address, contractId, patientId);

            // Assert
            Assert.NotNull(label);
            Assert.Equal(productionDate, label.ProductionDate);
            Assert.Equal(expirationDate, label.ExpirationDate);
            Assert.Equal(deliberyDate, label.DeliberyDate);
            Assert.Equal(detail, label.Detail);
            Assert.Equal(address, label.Address);
            Assert.Equal(contractId, label.ContractId);
            Assert.Equal(patientId, label.PatientId);
            Assert.NotEqual(Guid.Empty, label.Id); 
        }
    }
}
