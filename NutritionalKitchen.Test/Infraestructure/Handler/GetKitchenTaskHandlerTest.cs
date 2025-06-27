using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.KitchenTask.GetKitchenTask;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Infrastructure.Handlers;
using NutritionalKitchen.Infrastructure.StoredModel;
using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructure.Handler
{
    public class GetKitchenTaskHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetKitchenTaskHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllKitchenTasks()
        {
            // Arrange
            var kitchenTasks = new List<KitchenTaskStoredModel>
            {
                new KitchenTaskStoredModel
                {
                    Id = Guid.NewGuid(),
                    Description = "Desc1",
                    Status = "Status1",
                    Kitchener = "Chef1",
                    PreparationDate = DateTime.Today
                },
                new KitchenTaskStoredModel
                {
                    Id = Guid.NewGuid(),
                    Description = "Desc2",
                    Status = "Status2",
                    Kitchener = "Chef2",
                    PreparationDate = DateTime.Today
                }
            };

            _dbContext.Setup(db => db.KitchenTask).ReturnsDbSet(kitchenTasks);

            var handler = new GetKitchenTaskHandler(_dbContext.Object);
            var cancellationToken = new CancellationTokenSource(1000).Token;
            var query = new GetKitchenTaskQuery(""); 

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.Contains(list, t => t.Description == "Desc1" && t.Kitchener == "Chef1");
            Assert.Contains(list, t => t.Description == "Desc2" && t.Status == "Status2");
        }
    }
}
