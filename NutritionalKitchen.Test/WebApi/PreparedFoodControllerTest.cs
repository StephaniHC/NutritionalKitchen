using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.PreparedFood.CreatePreparedFood;
using NutritionalKitchen.Application.PreparedFood.GetPreparedFood;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class PreparedFoodControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PreparedFoodController _controller;

        public PreparedFoodControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PreparedFoodController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreatePreparedFood_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreatePreparedFoodCommand(
                idKitchenTask: Guid.NewGuid(),
                idRecipePreparation: Guid.NewGuid(),
                recipePreparationDate: DateTime.UtcNow,
                status: "Ready",
                recipe: "Receta Ejemplo",
                detail: "Detalle Ejemplo",
                patientId: Guid.NewGuid(),
                labelId: Guid.NewGuid()
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
        public async Task CreatePreparedFood_Returns500_WhenExceptionThrown()
        {
            // Arrange
            var command = new CreatePreparedFoodCommand(
                idKitchenTask: Guid.NewGuid(),
                idRecipePreparation: Guid.NewGuid(),
                recipePreparationDate: DateTime.UtcNow,
                status: "Ready",
                recipe: "Receta Error",
                detail: "Detalle Error",
                patientId: Guid.NewGuid(),
                labelId: Guid.NewGuid()
            );

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al crear comida preparada"));

            // Act
            var result = await _controller.CreateKitchenTask(command);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al crear comida preparada", objectResult.Value);
        }

        [Fact]
        public async Task GetPreparedFood_ReturnsOk_WithList()
        {
            // Arrange
            var preparedFoods = new List<PreparedFoodDTO>
            {
                new PreparedFoodDTO { Id = Guid.NewGuid(), IdKitchenTask = Guid.NewGuid() },
                new PreparedFoodDTO { Id = Guid.NewGuid(), IdKitchenTask = Guid.NewGuid() }
            };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetPreparedFoodQuery>(q => q.SearchTerm == ""), It.IsAny<CancellationToken>()))
                .ReturnsAsync(preparedFoods);

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PreparedFoodDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetPreparedFood_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPreparedFoodQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener comidas preparadas"));

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener comidas preparadas", objectResult.Value);
        }
    }
}
