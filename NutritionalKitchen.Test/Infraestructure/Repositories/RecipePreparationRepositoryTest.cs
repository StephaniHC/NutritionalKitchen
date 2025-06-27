using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.RecipePreparation;
using NutritionalKitchen.Infrastructure.DomainModel;
using NutritionalKitchen.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.Repositories
{
    public class RecipePreparationRepositoryTest
    {
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly RecipePreparationRepository _repository;

        public RecipePreparationRepositoryTest()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<DomainDbContext>();
            _mockDbContext = new Mock<DomainDbContext>(options);
            _repository = new RecipePreparationRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldCallAddAsyncOnDbSet()
        {
            // Arrange
            var recipePreparation = new RecipePreparation(
                recipeName: "Paella",
                detail: "Preparar con mariscos",
                preparationDate: DateTime.Today,
                patientId: Guid.NewGuid()
            );
            var emptyList = new List<RecipePreparation>();

            _mockDbContext.Setup(x => x.RecipePreparation).ReturnsDbSet(emptyList);

            // Act
            await _repository.AddAsync(recipePreparation);

            // Assert
            _mockDbContext.Verify(x => x.RecipePreparation.AddAsync(recipePreparation, default), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallUpdateOnDbSet()
        {
            // Arrange
            var recipePreparation = new RecipePreparation(
                recipeName: "Paella",
                detail: "Preparar con mariscos",
                preparationDate: DateTime.Today,
                patientId: Guid.NewGuid()
            );
            var emptyList = new List<RecipePreparation>();

            _mockDbContext.Setup(x => x.RecipePreparation).ReturnsDbSet(emptyList);

            // Act
            await _repository.UpdateAsync(recipePreparation);

            // Assert
            _mockDbContext.Verify(x => x.RecipePreparation.Update(recipePreparation), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenExists()
        {
            // Arrange
            var recipePreparation = new RecipePreparation(
                recipeName: "Paella",
                detail: "Preparar con mariscos",
                preparationDate: DateTime.Today,
                patientId: Guid.NewGuid()
            );

            var list = new List<RecipePreparation> { recipePreparation };

            _mockDbContext.Setup(x => x.RecipePreparation).ReturnsDbSet(list);

            // Act
            var result = await _repository.GetByIdAsync(recipePreparation.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(recipePreparation.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRemoveOnDbSet()
        {
            // Arrange
            var recipePreparation = new RecipePreparation(
                recipeName: "Paella",
                detail: "Preparar con mariscos",
                preparationDate: DateTime.Today,
                patientId: Guid.NewGuid()
            );

            var list = new List<RecipePreparation> { recipePreparation };

            _mockDbContext.Setup(x => x.RecipePreparation).ReturnsDbSet(list);

            // Act
            await _repository.DeleteAsync(recipePreparation.Id);

            // Assert
            _mockDbContext.Verify(x => x.RecipePreparation.Remove(recipePreparation), Times.Once);
        }

    }
}
