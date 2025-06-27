using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.PreparedFood.GetPreparedFood;
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
    public class GetPreparedFoodHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetPreparedFoodHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllPreparedFoods()
        {
            // Arrange: Datos simulados
            var preparedFoods = new List<PreparedFoodStoredModel>
            {
                new PreparedFoodStoredModel
                {
                    Id = Guid.NewGuid(),
                    IdKitchenTask = Guid.NewGuid()
                },
                new PreparedFoodStoredModel
                {
                    Id = Guid.NewGuid(),
                    IdKitchenTask = Guid.NewGuid()
                }
            };

            _dbContext.Setup(db => db.PreparedFood).ReturnsDbSet(preparedFoods);

            var handler = new GetPreparedFoodHandler(_dbContext.Object);
            var cancellationToken = new CancellationTokenSource(1000).Token;
            var query = new GetPreparedFoodQuery(""); 

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.All(list, item => Assert.NotEqual(Guid.Empty, item.Id));
            Assert.All(list, item => Assert.NotEqual(Guid.Empty, item.IdKitchenTask));
        }
    }
}
