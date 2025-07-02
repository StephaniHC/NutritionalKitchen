using NutritionalKitchen.Integration.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Integration
{
    public class PackageCreatedTest
    {
        [Fact]
        public void Constructor_ShouldAssign_AllProperties()
        {
            // Arrange
            var packageId = Guid.NewGuid();
            var status = "CREATED";
            var correlationId = "corr-001";
            var source = "UnitTest";

            // Act
            var message = new PackageCreated(packageId, status, correlationId, source);

            // Assert
            Assert.Equal(packageId, message.PackageId);
            Assert.Equal(status, message.Status);
            Assert.Equal(correlationId, message.CorrelationId);
            Assert.Equal(source, message.Source);
        }

        [Fact]
        public void Constructor_ShouldAllow_NullableFields()
        {
            // Arrange
            var packageId = Guid.NewGuid();

            // Act
            var message = new PackageCreated(packageId, null);

            // Assert
            Assert.Equal(packageId, message.PackageId);
            Assert.Null(message.Status);
            Assert.Null(message.CorrelationId);
            Assert.Null(message.Source);
        }
    }
}
