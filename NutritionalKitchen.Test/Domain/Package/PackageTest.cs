using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Package
{
    public class PackageTest
    {
        [Fact]
        public void Constructor_ShouldInitializeAllProperties()
        {
            // Arrange
            var status = "Delivered";
            var labelId = Guid.NewGuid();

            // Act
            var package = new NutritionalKitchen.Domain.Package.Package(status, labelId);

            // Assert
            Assert.NotNull(package);
            Assert.Equal(status, package.Status);
            Assert.Equal(labelId, package.LabelId);
            Assert.NotEqual(Guid.Empty, package.Id);  
        }
    }
}
