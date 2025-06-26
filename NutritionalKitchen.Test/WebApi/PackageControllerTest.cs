using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Application.Package.GetPackage;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.WebApi
{
    public class PackageControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PackageController _controller;

        public PackageControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PackageController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreatePackage_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreatePackageCommand("PENDING", Guid.NewGuid());
            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateKitchenTask(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, okResult.Value);
        }

        [Fact]
        public async Task CreatePackage_Returns500_WhenExceptionThrown()
        {
            // Arrange
            var command = new CreatePackageCommand("ERROR", Guid.NewGuid());

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al crear paquete"));

            // Act
            var result = await _controller.CreateKitchenTask(command);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al crear paquete", objectResult.Value);
        }

        [Fact]
        public async Task GetPackage_ReturnsOk_WithList()
        {
            // Arrange
            var packages = new List<PackageDTO>
        {
            new PackageDTO
            {
                Id = Guid.NewGuid(),
                Status = "ENVIADO",
                LabelId = Guid.NewGuid()
            },
            new PackageDTO
            {
                Id = Guid.NewGuid(),
                Status = "PENDIENTE",
                LabelId = Guid.NewGuid()
            }
        };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetPackageQuery>(q => q.SearchTerm == ""), It.IsAny<CancellationToken>()))
                .ReturnsAsync(packages);

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PackageDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
            Assert.Contains(returnValue, p => p.Status == "ENVIADO");
        }

        [Fact]
        public async Task GetPackage_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPackageQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener paquetes"));

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener paquetes", objectResult.Value);
        }
    } 
}
