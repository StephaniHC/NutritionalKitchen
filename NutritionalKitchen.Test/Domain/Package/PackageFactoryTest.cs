using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Package
{
    public class PackageFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnPackage_WithCorrectProperties()
        {
            // Arrange
            var factory = new PackageFactory();
            var status = "Ready";
            var labelId = Guid.NewGuid();

            // Act
            var result = factory.Create(status, labelId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(status, result.Status);
            Assert.Equal(labelId, result.LabelId);
        }
    }
}
