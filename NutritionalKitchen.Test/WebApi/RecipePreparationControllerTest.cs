using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.WebApi
{
    public class RecipePreparationControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly RecipePreparationController _controller;

        public RecipePreparationControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new RecipePreparationController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateRecipePreparation_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreateRecipePreparationCommand(
                "Receta A",
                "Detalle prueba",
                DateTime.UtcNow,
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
        public async Task CreateRecipePreparation_Returns500_WhenExceptionThrown()
        {
            // Arrange
            var command = new CreateRecipePreparationCommand(
                "Receta B",
                "Error esperado",
                DateTime.UtcNow,
                Guid.NewGuid()
            );

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al crear preparación de receta"));

            // Act
            var result = await _controller.CreateKitchenTask(command);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al crear preparación de receta", objectResult.Value);
        }

        [Fact]
        public async Task GetRecipePreparation_ReturnsOk_WithList()
        {
            // Arrange
            var items = new List<RecipePreparationDTO>
        {
            new RecipePreparationDTO
            {
                Id = Guid.NewGuid(),
                RecipeName = "Receta 1",
                Detail = "Preparar con arroz",
                PreparationDate = DateTime.UtcNow,
                PatientId = Guid.NewGuid()
            },
            new RecipePreparationDTO
            {
                Id = Guid.NewGuid(),
                RecipeName = "Receta 2",
                Detail = "Incluir proteína",
                PreparationDate = DateTime.UtcNow,
                PatientId = Guid.NewGuid()
            }
        };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetRecipePreparationQuery>(q => q.SearchTerm == ""), It.IsAny<CancellationToken>()))
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RecipePreparationDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
            Assert.Contains(returnValue, r => r.RecipeName == "Receta 1");
        }

        [Fact]
        public async Task GetRecipePreparation_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipePreparationQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener preparaciones de receta"));

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener preparaciones de receta", objectResult.Value);
        }
    } 
}
