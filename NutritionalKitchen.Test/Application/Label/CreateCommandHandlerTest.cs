using Moq;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Label;
using Xunit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application.Label
{
    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreateLabel_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var labelId = Guid.NewGuid();
            var productionDate = DateTime.UtcNow;
            var expirationDate = productionDate.AddDays(10);
            var deliberyDate = productionDate.AddDays(2);
            var detail = "Etiqueta para paciente con dieta líquida";
            var address = "Calle 123";
            var contractId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var deliberyId = Guid.NewGuid();
            var status = true;

            var command = new CreateLabelCommand(
                labelId,                // <-- AHORA CON id
                productionDate,
                expirationDate,
                deliberyDate,
                detail,
                address,
                contractId,
                patientId,
                deliberyId,
                status
            );

            var mockLabelFactory = new Mock<ILabelFactory>();
            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdLabel = new NutritionalKitchen.Domain.Label.Label(
                labelId,               // <-- id también aquí
                productionDate,
                expirationDate,
                deliberyDate,
                detail,
                address,
                contractId,
                patientId,
                deliberyId,
                status
            );

            mockLabelFactory
                .Setup(f => f.Create(
                    labelId,
                    productionDate,
                    expirationDate,
                    deliberyDate,
                    detail,
                    address,
                    contractId,
                    patientId,
                    deliberyId,
                    status))
                .Returns(createdLabel);

            var handler = new CreateCommandHandler(
                mockLabelFactory.Object,
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(labelId, result);
            mockLabelFactory.Verify(f => f.Create(
                labelId,
                productionDate,
                expirationDate,
                deliberyDate,
                detail,
                address,
                contractId,
                patientId,
                deliberyId,
                status), Times.Once);

            mockLabelRepository.Verify(r => r.AddAsync(createdLabel), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitBulkAsync(It.IsAny<CancellationToken>()), Times.Once);  
        }
    }
}
