using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Application.Label.GetLabel;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.WebApi
{
    public class LabelControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly LabelController _controller;

        public LabelControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new LabelController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateLabel_ReturnsOk_WhenCommandSucceeds()
        {
            // Arrange
            var command = new CreateLabelCommand(
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(10),
                DateTime.UtcNow.AddDays(1),
                "Detalle de prueba",
                "Av. Siempre Viva 123",
                Guid.NewGuid(),
                Guid.NewGuid()
            );

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
        public async Task CreateLabel_Returns500_WhenExceptionThrown()
        {
            // Arrange
            var command = new CreateLabelCommand(
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(10),
                DateTime.UtcNow.AddDays(1),
                "Detalle de error",
                "Calle Falsa 456",
                Guid.NewGuid(),
                Guid.NewGuid()
            );

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al crear etiqueta"));

            // Act
            var result = await _controller.CreateKitchenTask(command);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al crear etiqueta", objectResult.Value);
        }

        [Fact]
        public async Task GetLabel_ReturnsOk_WithListOfLabels()
        {
            // Arrange
            var labels = new List<LabelDTO>
        {
            new LabelDTO
            {
                Id = Guid.NewGuid(),
                ProductionDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddDays(30),
                DeliberyDate = DateTime.UtcNow.AddDays(1),
                Detail = "Etiqueta 1",
                Address = "Calle 1",
                ContractId = Guid.NewGuid(),
                PatientId = Guid.NewGuid()
            },
            new LabelDTO
            {
                Id = Guid.NewGuid(),
                ProductionDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddDays(20),
                DeliberyDate = DateTime.UtcNow.AddDays(2),
                Detail = "Etiqueta 2",
                Address = "Calle 2",
                ContractId = Guid.NewGuid(),
                PatientId = Guid.NewGuid()
            }
        };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetLabelQuery>(q => q.SearchTerm == ""), It.IsAny<CancellationToken>()))
                .ReturnsAsync(labels);

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<LabelDTO>>(okResult.Value);

            Assert.Equal(2, returnValue.Count());
            Assert.Contains(returnValue, l => l.Detail == "Etiqueta 1");
        }

        [Fact]
        public async Task GetLabel_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLabelQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener etiquetas"));

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener etiquetas", objectResult.Value);
        }
    }

}
