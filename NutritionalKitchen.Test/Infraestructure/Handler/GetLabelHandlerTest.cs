using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.Label.GetLabel;
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
    public class GetLabelHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetLabelHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllLabels()
        {
            // Arrange
            var labels = new List<LabelStoredModel>
            {
                new LabelStoredModel
                {
                    Id = Guid.NewGuid(),
                    ProductionDate = DateTime.Today.AddDays(-1),
                    ExpirationDate = DateTime.Today.AddDays(5),
                    DeliberyDate = DateTime.Today,
                    Detail = "Label 1 Detail",
                    Address = "123 Main St",
                    ContractId = Guid.NewGuid(),
                    PatientId = Guid.NewGuid()
                },
                new LabelStoredModel
                {
                    Id = Guid.NewGuid(),
                    ProductionDate = DateTime.Today.AddDays(-2),
                    ExpirationDate = DateTime.Today.AddDays(4),
                    DeliberyDate = DateTime.Today,
                    Detail = "Label 2 Detail",
                    Address = "456 Side Ave",
                    ContractId = Guid.NewGuid(),
                    PatientId = Guid.NewGuid()
                }
            };

            _dbContext.Setup(db => db.Label).ReturnsDbSet(labels);

            var handler = new GetLabelHandler(_dbContext.Object);
            var cancellationToken = new CancellationTokenSource(1000).Token;
            var query = new GetLabelQuery("");  

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.Contains(list, l => l.Detail == "Label 1 Detail" && l.Address == "123 Main St");
            Assert.Contains(list, l => l.Detail == "Label 2 Detail" && l.Address == "456 Side Ave");
        }
    }
}
