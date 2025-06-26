using Moq;
using NutritionalKitchen.Application.KitchenTask.CreateKitchenTask;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application.KitchenTask
{
    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreateKitchenTask_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var expectedId = Guid.NewGuid();

            var command = new CreateKitchenTaskCommand(
                "description test",
                "PENDING",
                "JUAN",
                DateTime.UtcNow
            );

            var createdKitchenTask = new NutritionalKitchen.Domain.KitchenTask.KitchenTask( 
                command.description,
                command.status,
                command.kitchener,
                command.preparationDate
            );

            var mockFactory = new Mock<IKitchenTaskFactory>();
            var mockRepository = new Mock<IKitchenTaskRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockFactory
                .Setup(f => f.Create(
                    command.description,
                    command.status,
                    command.kitchener,
                    command.preparationDate))
                .Returns(createdKitchenTask);

            var handler = new CreateCommandHandler(
                mockFactory.Object,
                mockRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert  
            mockFactory.Verify(f => f.Create(
                command.description,
                command.status,
                command.kitchener,
                command.preparationDate), Times.Once);

            mockRepository.Verify(r => r.AddAsync(createdKitchenTask), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(CancellationToken.None), Times.Once);
        }

    }
}
