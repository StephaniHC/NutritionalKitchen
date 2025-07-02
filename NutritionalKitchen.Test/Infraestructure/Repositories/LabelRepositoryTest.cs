using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Infrastructure.DomainModel;
using NutritionalKitchen.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.Repositories
{
    public class LabelRepositoryTest
    {
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly LabelRepository _repository;

        public LabelRepositoryTest()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<DomainDbContext>();
            _mockDbContext = new Mock<DomainDbContext>(options);
            _repository = new LabelRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddLabel()
        {
            // Arrange
            var labels = new List<Label>();
            _mockDbContext.Setup(x => x.Label).ReturnsDbSet(labels);

            var label = new Label(
                productionDate: DateTime.Today,
                expirationDate: DateTime.Today.AddDays(10),
                deliberyDate: DateTime.Today.AddDays(1),
                detail: "detail",
                address: "address",
                contractId: Guid.NewGuid(),
                patientId: Guid.NewGuid(),
                deliberyId: Guid.NewGuid(),
                status: true);

            // Act
            await _repository.AddAsync(label);

            // Assert
            _mockDbContext.Verify(x => x.Label.AddAsync(label, default), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveLabel_WhenExists()
        {
            // Arrange
            var label = new Label(
                productionDate: DateTime.Today,
                expirationDate: DateTime.Today.AddDays(10),
                deliberyDate: DateTime.Today.AddDays(1),
                detail: "detail",
                address: "address",
                contractId: Guid.NewGuid(),
                patientId: Guid.NewGuid(),
                deliberyId: Guid.NewGuid(),
                status: true);

            var labels = new List<Label> { label };
            _mockDbContext.Setup(db => db.Label).ReturnsDbSet(labels);

            // Act
            await _repository.DeleteAsync(label.Id);

            // Assert
            _mockDbContext.Verify(x => x.Label.Remove(label), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnLabel_WhenExists()
        {
            // Arrange
            var label = new Label(
                productionDate: DateTime.Today,
                expirationDate: DateTime.Today.AddDays(10),
                deliberyDate: DateTime.Today.AddDays(1),
                detail: "detail",
                address: "address",
                contractId: Guid.NewGuid(),
                patientId: Guid.NewGuid(),
                deliberyId: Guid.NewGuid(),
                status: true);

            var labels = new List<Label> { label };
            _mockDbContext.Setup(db => db.Label).ReturnsDbSet(labels);

            // Act
            var result = await _repository.GetByIdAsync(label.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(label.Id, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            var labels = new List<Label>();
            _mockDbContext.Setup(db => db.Label).ReturnsDbSet(labels);

            // Act
            var result = await _repository.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateLabel()
        {
            // Arrange
            var labels = new List<Label>();
            _mockDbContext.Setup(x => x.Label).ReturnsDbSet(labels);

            var label = new Label(
                productionDate: DateTime.Today,
                expirationDate: DateTime.Today.AddDays(10),
                deliberyDate: DateTime.Today.AddDays(1),
                detail: "detail",
                address: "address",
                contractId: Guid.NewGuid(),
                patientId: Guid.NewGuid(),
                deliberyId: Guid.NewGuid(),
                status: true);

            // Act
            await _repository.UpdateAsync(label);

            // Assert
            _mockDbContext.Verify(x => x.Label.Update(label), Times.Once);
        }
    }
}
