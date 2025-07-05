using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Infrastructure.DomainModel;
using NutritionalKitchen.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.Repositories
{
    public class KitchenTaskRepositoryTest
    {
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly KitchenTaskRepository _repository;

        public KitchenTaskRepositoryTest()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<DomainDbContext>();
            _mockDbContext = new Mock<DomainDbContext>(options);
            _repository = new KitchenTaskRepository(_mockDbContext.Object);
        }
        [Fact]
        public async Task AddAsync_ShouldAddKitchenTask()
        {
            // Arrange
            var task = new KitchenTask("Chef", DateTime.Today);

            _mockDbContext.Setup(x => x.KitchenTask).ReturnsDbSet(new List<KitchenTask>());

            // Act
            await _repository.AddAsync(task);

            // Assert
            _mockDbContext.Verify(x => x.KitchenTask.AddAsync(task, default), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnKitchenTask_WhenExists()
        {
            // Arrange
            var task = new KitchenTask("Chef", DateTime.Today);
            var data = new List<KitchenTask> { task };

            _mockDbContext.Setup(x => x.KitchenTask).ReturnsDbSet(data);

            // Act
            var result = await _repository.GetByIdAsync(task.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(task.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveKitchenTask_WhenExists()
        {
            // Arrange
            var task = new KitchenTask("Chef", DateTime.Today);
            var data = new List<KitchenTask> { task };

            _mockDbContext.Setup(x => x.KitchenTask).ReturnsDbSet(data);

            // Act
            await _repository.DeleteAsync(task.Id);

            // Assert
            _mockDbContext.Verify(x => x.KitchenTask.Remove(It.Is<KitchenTask>(k => k.Id == task.Id)), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateKitchenTask()
        {
            // Arrange
            var task = new KitchenTask("Chef", DateTime.Today);

            _mockDbContext.Setup(x => x.KitchenTask).ReturnsDbSet(new List<KitchenTask>());

            // Act
            await _repository.UpdateAsync(task);

            // Assert
            _mockDbContext.Verify(x => x.KitchenTask.Update(task), Times.Once);
        }
    }
}
