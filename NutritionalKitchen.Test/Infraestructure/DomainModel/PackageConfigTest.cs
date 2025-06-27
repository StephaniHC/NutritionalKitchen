using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infrastructure.DomainModel.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.DomainModel
{
    public class PackageConfigTest
    {
        [Fact]
        public void PackageConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var config = new PackageConfig();

            // Act
            config.Configure(modelBuilder.Entity<Package>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(Package));
            Assert.NotNull(entityType);
            Assert.Equal("Package", entityType.GetTableName());

            var idProperty = entityType.FindProperty("Id");
            Assert.NotNull(idProperty);
            Assert.Equal("Id", idProperty.Name);

            var statusProperty = entityType.FindProperty("Status");
            Assert.NotNull(statusProperty);
            Assert.Equal("Status", statusProperty.Name);

            var labelIdProperty = entityType.FindProperty("LabelId");
            Assert.NotNull(labelIdProperty);
            Assert.Equal("LabelId", labelIdProperty.Name);
        }
    }
}
