using Moq;
using NutritionalKitchen.Application.PreparedFood.CreatePreparedFood;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

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
            var recipePreparationId = Guid.NewGuid();
            var recipePreparationDate = DateTime.UtcNow.Date;
            var status = "Preparado";
            var recipe = "Sopa de verduras";
            var detail = "Sin sal, dieta blanda";
            var patientId = Guid.NewGuid();

            var command = new CreatePreparedFoodCommand(
                kitchenTaskId,
                recipePreparationId,
                recipePreparationDate,
                status,
                recipe,
                detail,
                patientId
            );

            var mockFactory = new Mock<IPreparedFoodFactory>();
            var mockRepository = new Mock<IPreparedFoodRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdPreparedFood = new NutritionalKitchen.Domain.PreparedFood.PreparedFood(
                kitchenTaskId,
                recipePreparationId,
                recipePreparationDate,
                status,
                recipe,
                detail,
                patientId
            );

            mockFactory
                .Setup(f => f.Create(
                    kitchenTaskId,
                    recipePreparationId,
                    recipePreparationDate,
                    status,
                    recipe,
                    detail,
                    patientId))
                .Returns(createdPreparedFood);

            var handler = new CreateCommandHandler(
                mockFactory.Object,
                mockRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(createdPreparedFood.Id, result);
            mockFactory.Verify(f => f.Create(
                kitchenTaskId,
                recipePreparationId,
                recipePreparationDate,
                status,
                recipe,
                detail,
                patientId), Times.Once);

            mockRepository.Verify(r => r.AddAsync(createdPreparedFood), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
