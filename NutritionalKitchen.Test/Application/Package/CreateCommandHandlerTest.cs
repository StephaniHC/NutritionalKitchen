using Moq;
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application.Package
{

    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreatePackage_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var packageId = Guid.NewGuid();
            var labelId = Guid.NewGuid();
            var status = "CREATED";

            var command = new CreatePackageCommand(status, labelId);

            var mockFactory = new Mock<IPackageFactory>();
            var mockRepository = new Mock<IPackageRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdPackage = new NutritionalKitchen.Domain.Package.Package( 
                status,
                labelId
            );

            mockFactory
                .Setup(f => f.Create(status, labelId))
                .Returns(createdPackage);

            var handler = new CreateCommandHandler(
                mockFactory.Object,
                mockRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert 
            mockFactory.Verify(f => f.Create(status, labelId), Times.Once);
            mockRepository.Verify(r => r.AddAsync(createdPackage), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
