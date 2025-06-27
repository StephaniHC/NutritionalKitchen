using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.Package.GetPackage;
using NutritionalKitchen.Infrastructure.Handlers;
using NutritionalKitchen.Infrastructure.StoredModel;
using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.Handler
{
    public class GetPackageHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetPackageHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllPackages()
        {
            // Arrange 
            var packages = new List<PackageStoredModel>
            {
                new PackageStoredModel
                {
                    Id = Guid.NewGuid(),
                    Status = "Ready",
                    LabelId = Guid.NewGuid()
                },
                new PackageStoredModel
                {
                    Id = Guid.NewGuid(),
                    Status = "Delivered",
                    LabelId = Guid.NewGuid()
                }
            };

            _dbContext.Setup(db => db.Package).ReturnsDbSet(packages);

            var handler = new GetPackageHandler(_dbContext.Object);
            var cancellationToken = new CancellationTokenSource(1000).Token;
            var query = new GetPackageQuery(""); 

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.Contains(list, p => p.Status == "Ready");
            Assert.Contains(list, p => p.Status == "Delivered");
        }
    }
}
