using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation;
using NutritionalKitchen.Application.RecipePreparation.GetRecipe;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

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
                id: Guid.NewGuid(),
                recipeId: Guid.NewGuid(),
                detail: "Receta B",
                mealTime: "Error esperado",
                preparationDate: DateTime.UtcNow,
                patientId: Guid.NewGuid()
            );

            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateRecipePreparation(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, okResult.Value);
        }

        [Fact]
        public async Task CreateRecipePreparation_Returns500_WhenExceptionThrown()
        {
            // Arrange
            var command = new CreateRecipePreparationCommand(
                id: Guid.NewGuid(),
                recipeId: Guid.NewGuid(),
                detail: "Receta B",
                mealTime: "Error esperado",
                preparationDate: DateTime.UtcNow,
                patientId: Guid.NewGuid()
            );

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al crear preparación de receta"));

            // Act
            var result = await _controller.CreateRecipePreparation(command);

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
                    Detail = "Preparar con arroz",
                    PreparationDate = DateTime.UtcNow,
                    PatientId = Guid.NewGuid()
                },
                new RecipePreparationDTO
                {
                    Id = Guid.NewGuid(),
                    Detail = "Incluir proteína",
                    PreparationDate = DateTime.UtcNow,
                    PatientId = Guid.NewGuid()
                }
            };

            _mediatorMock
                .Setup(m => m.Send(It.Is<GetRecipePreparationQuery>(q => q.SearchTerm == ""), It.IsAny<CancellationToken>()))
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetRecipePreparation();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RecipePreparationDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetRecipePreparation_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipePreparationQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener preparaciones de receta"));

            // Act
            var result = await _controller.GetRecipePreparation();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener preparaciones de receta", objectResult.Value);
        }

        [Fact]
        public async Task GetRecipe_ReturnsOk_WithList()
        {
            // Arrange
            var items = new List<RecipeDTO>
            {
                new RecipeDTO { Id = Guid.NewGuid(), Description = "Receta 1" },
                new RecipeDTO { Id = Guid.NewGuid(), Description = "Receta 2" }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetRecipe();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RecipeDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetRecipe_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipeQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener recetas"));

            // Act
            var result = await _controller.GetRecipe();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener recetas", objectResult.Value);
        }

        [Fact]
        public async Task GetTodayRecipePreparation_ReturnsOk_WithList()
        {
            // Arrange
            var items = new List<RecipePreparationDTO>
            {
                new RecipePreparationDTO
                {
                    Id = Guid.NewGuid(),
                    Detail = "Hoy - sopa",
                    PreparationDate = DateTime.UtcNow,
                    PatientId = Guid.NewGuid()
                }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipePreparationByTodayQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetTodayRecipePreparation();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<RecipePreparationDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetTodayRecipePreparation_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipePreparationByTodayQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener recetas del día"));

            // Act
            var result = await _controller.GetTodayRecipePreparation();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener recetas del día", objectResult.Value);
        }
    }
}
