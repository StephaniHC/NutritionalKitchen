using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;
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
    public class GetRecipePreparationHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetRecipePreparationHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllRecipePreparations()
        {
            // Arrange 
            var recipes = new List<RecipePreparationStoredModel>
            {
                new RecipePreparationStoredModel
                {
                    Id = Guid.NewGuid(),
                    RecipeName = "Ensalada César",
                    Detail = "Sin sal",
                    PreparationDate = DateTime.Today,
                    PatientId = Guid.NewGuid()
                },
                new RecipePreparationStoredModel
                {
                    Id = Guid.NewGuid(),
                    RecipeName = "Sopa de verduras",
                    Detail = "Baja en grasa",
                    PreparationDate = DateTime.Today,
                    PatientId = Guid.NewGuid()
                }
            };

            _dbContext.Setup(db => db.RecipePreparation).ReturnsDbSet(recipes);

            var handler = new GetRecipePreparationHandler(_dbContext.Object);
            var cancellationToken = new CancellationTokenSource(1000).Token;
            var query = new GetRecipePreparationQuery(""); 

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.Contains(list, r => r.RecipeName == "Ensalada César" && r.Detail == "Sin sal");
            Assert.Contains(list, r => r.RecipeName == "Sopa de verduras" && r.Detail == "Baja en grasa");
        }
    }
}
