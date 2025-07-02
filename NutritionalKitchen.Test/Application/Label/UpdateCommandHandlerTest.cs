using MediatR;
using Moq;
using NutritionalKitchen.Application.Label.UpdateLabel;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application.Label
{
    public class UpdateCommandHandlerTest
    {

        [Fact]
        public async Task Handle_ShouldUpdateLabel_WhenLabelExists()
        {
            // Arrange
            var deliberyId = Guid.NewGuid();
            var address = "Calle Nueva";

            var command = new UpdateLabelCommand
            {
                DeliberyId = deliberyId,
                Address = address
            };

            var existingLabel = new NutritionalKitchen.Domain.Label.Label(
                productionDate: DateTime.UtcNow,
                expirationDate: DateTime.UtcNow.AddDays(10),
                deliberyDate: DateTime.UtcNow.AddDays(1),
                detail: "Original detail",
                address: "Antigua dirección",
                contractId: Guid.NewGuid(),
                patientId: Guid.NewGuid(),
                deliberyId: deliberyId,
                status: true
            );

            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockLabelRepository
                .Setup(r => r.GetByIdAsync(deliberyId))
                .ReturnsAsync(existingLabel);

            var handler = new UpdateCommandHandler(
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(address, existingLabel.Address); // Verifica el cambio real en la entidad

            mockLabelRepository.Verify(r => r.UpdateAsync(existingLabel), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenLabelNotFound()
        {
            // Arrange
            var command = new UpdateLabelCommand
            {
                DeliberyId = Guid.NewGuid(),
                Address = "Nueva dirección"
            };

            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockLabelRepository
                .Setup(r => r.GetByIdAsync(command.DeliberyId))
                .ReturnsAsync((Label?)null); 

            var handler = new UpdateCommandHandler(
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                handler.Handle(command, CancellationToken.None)
            );

            Assert.Contains("not found", ex.Message);
        }
    }
}
