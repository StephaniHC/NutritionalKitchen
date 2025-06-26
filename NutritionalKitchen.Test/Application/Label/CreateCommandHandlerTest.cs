using Moq;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var command = new CreateLabelCommand(
                productionDate,
                expirationDate,
                deliberyDate,
                detail,
                address,
                contractId,
                patientId
            );

            var mockLabelFactory = new Mock<ILabelFactory>();
            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdLabel = new NutritionalKitchen.Domain.Label.Label( 
                productionDate,
                expirationDate,
                deliberyDate,
                detail,
                address,
                contractId,
                patientId
            );

            mockLabelFactory
                .Setup(f => f.Create(productionDate, expirationDate, deliberyDate, detail, address, contractId, patientId))
                .Returns(createdLabel);

            var handler = new CreateCommandHandler(
                mockLabelFactory.Object,
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert  
            mockLabelFactory.Verify(f => f.Create(productionDate, expirationDate, deliberyDate, detail, address, contractId, patientId), Times.Once);
            mockLabelRepository.Verify(r => r.AddAsync(createdLabel), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
