using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Infrastructure.DomainModel;
using NutritionalKitchen.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.Repositories
{
    public class PreparedFoodRepositoryTest
    {
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly PreparedFoodRepository _repository;

        public PreparedFoodRepositoryTest()
        { 
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<DomainDbContext>();
            _mockDbContext = new Mock<DomainDbContext>(options);
            _repository = new PreparedFoodRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsyncOnDbSet()
        {
            // Arrange
            var preparedFood = new PreparedFood(Guid.NewGuid());
            var emptyList = new List<PreparedFood>();

            // Configurar el DbSet mock para PreparedFood
            _mockDbContext.Setup(x => x.PreparedFood).ReturnsDbSet(emptyList);

            // Act
            await _repository.AddAsync(preparedFood);

            // Assert
            _mockDbContext.Verify(x => x.PreparedFood.AddAsync(preparedFood, default), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRemoveOnDbSet()
        {
            // Arrange
            var preparedFood = new PreparedFood(Guid.NewGuid());
            var data = new List<PreparedFood> { preparedFood };

            _mockDbContext.Setup(x => x.PreparedFood).ReturnsDbSet(data);

            // Act
            await _repository.DeleteAsync(preparedFood.Id);

            // Assert
            _mockDbContext.Verify(x => x.PreparedFood.Remove(preparedFood), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPreparedFood_WhenExists()
        {
            // Arrange
            var preparedFood = new PreparedFood(Guid.NewGuid());
            var data = new List<PreparedFood> { preparedFood };

            _mockDbContext.Setup(x => x.PreparedFood).ReturnsDbSet(data);

            // Act
            var result = await _repository.GetByIdAsync(preparedFood.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(preparedFood.Id, result.Id);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallUpdateOnDbSet()
        {
            // Arrange
            var preparedFood = new PreparedFood(Guid.NewGuid());
            var emptyList = new List<PreparedFood>();

            // Configurar el DbSet mock para PreparedFood
            _mockDbContext.Setup(x => x.PreparedFood).ReturnsDbSet(emptyList);

            // Act
            await _repository.UpdateAsync(preparedFood);

            // Assert
            _mockDbContext.Verify(x => x.PreparedFood.Update(preparedFood), Times.Once);
        }
    }
}
