using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Infrastructure.DomainModel.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.DomainModel
{
    public class LabelConfigTest
    {
        [Fact]
        public void LabelConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var config = new LabelConfig();

            // Act
            config.Configure(modelBuilder.Entity<Label>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(Label));
            Assert.NotNull(entityType);
            Assert.Equal("Label", entityType.GetTableName());

            var idProperty = entityType.FindProperty("Id");
            Assert.NotNull(idProperty);
            Assert.Equal("Id", idProperty.Name);

            var productionDateProperty = entityType.FindProperty("ProductionDate");
            Assert.NotNull(productionDateProperty);
            Assert.Equal("ProductionDate", productionDateProperty.Name);

            var expirationDateProperty = entityType.FindProperty("ExpirationDate");
            Assert.NotNull(expirationDateProperty);
            Assert.Equal("ExpirationDate", expirationDateProperty.Name);

            var deliberyDateProperty = entityType.FindProperty("DeliberyDate");
            Assert.NotNull(deliberyDateProperty);
            Assert.Equal("DeliberyDate", deliberyDateProperty.Name);

            var detailProperty = entityType.FindProperty("Detail");
            Assert.NotNull(detailProperty);
            Assert.Equal("Detail", detailProperty.Name);

            var addressProperty = entityType.FindProperty("Address");
            Assert.NotNull(addressProperty);
            Assert.Equal("Address", addressProperty.Name);

            var contractIdProperty = entityType.FindProperty("ContractId");
            Assert.NotNull(contractIdProperty);
            Assert.Equal("ContractId", contractIdProperty.Name);

            var patientIdProperty = entityType.FindProperty("PatientId");
            Assert.NotNull(patientIdProperty);
            Assert.Equal("PatientId", patientIdProperty.Name);
        }
    }
}
