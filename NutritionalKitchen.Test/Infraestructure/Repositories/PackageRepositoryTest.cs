using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infrastructure.DomainModel;
using NutritionalKitchen.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.Repositories
{
    public class PackageRepositoryTest
    {
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly PackageRepository _repository;

        public PackageRepositoryTest()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<DomainDbContext>();
            _mockDbContext = new Mock<DomainDbContext>(options);
            _repository = new PackageRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsyncOnDbSet()
        {
            // Arrange
            var packages = new List<Package>();
            _mockDbContext.Setup(x => x.Package).ReturnsDbSet(packages);

            var package = new Package("Pending", Guid.NewGuid());

            // Act
            await _repository.AddAsync(package);

            // Assert
            _mockDbContext.Verify(x => x.Package.AddAsync(package, default), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallUpdateOnDbSet()
        {
            // Arrange
            var packages = new List<Package>();
            _mockDbContext.Setup(x => x.Package).ReturnsDbSet(packages);

            var package = new Package("Pending", Guid.NewGuid());

            // Act
            await _repository.UpdateAsync(package);

            // Assert
            _mockDbContext.Verify(x => x.Package.Update(package), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPackage_WhenPackageExists()
        {
            // Arrange
            var package = new Package("Pending", Guid.NewGuid());
            var packages = new List<Package> { package };

            _mockDbContext.Setup(x => x.Package).ReturnsDbSet(packages);

            // Act
            var result = await _repository.GetByIdAsync(package.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(package.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRemoveOnDbSet()
        {
            // Arrange
            var package = new Package("Pending", Guid.NewGuid());
            var packages = new List<Package> { package };

            _mockDbContext.Setup(x => x.Package).ReturnsDbSet(packages);

            // Act
            await _repository.DeleteAsync(package.Id);

            // Assert
            _mockDbContext.Verify(x => x.Package.Remove(package), Times.Once);
        }

    }
}
