using Moq;
using NutritionalKitchen.Application.PreparedFood.CreatePreparedFood;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application.PreparedFood
{
    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreatePreparedFood_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var preparedFoodId = Guid.NewGuid();
            var kitchenTaskId = Guid.NewGuid();

            var command = new CreatePreparedFoodCommand(kitchenTaskId);

            var mockFactory = new Mock<IPreparedFoodFactory>();
            var mockRepository = new Mock<IPreparedFoodRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdPreparedFood = new NutritionalKitchen.Domain.PreparedFood.PreparedFood(
                kitchenTaskId
            );

            mockFactory
                .Setup(f => f.Create(kitchenTaskId))
                .Returns(createdPreparedFood);

            var handler = new CreateCommandHandler(
                mockFactory.Object,
                mockRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockFactory.Verify(f => f.Create(kitchenTaskId), Times.Once);
            mockRepository.Verify(r => r.AddAsync(createdPreparedFood), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
