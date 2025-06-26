using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.KitchenTask.CreateKitchenTask;
using NutritionalKitchen.Application.KitchenTask.GetKitchenTask;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.WebApi
{
    public class KitchenTaskControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly KitchenTaskController _controller;

        public KitchenTaskControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new KitchenTaskController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateKitchenTask_ReturnsOk_WhenCommandSucceeds()
        {
            // Arrange
            var command = new CreateKitchenTaskCommand(
                 "test",   
                 "PENDING",           
                 "JUAN",    
                 new DateTime(2025, 6, 26, 8, 30, 0) 
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
        public async Task CreateKitchenTask_Returns500_WhenExceptionThrown()
        {
            // Arrange 
            var command = new CreateKitchenTaskCommand(
                 "test",
                 "PENDING", 
                 "JUAN", 
                 new DateTime(2025, 6, 26, 8, 30, 0) 
             );
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al crear tarea"));

            // Act
            var result = await _controller.CreateKitchenTask(command);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al crear tarea", objectResult.Value);
        }

        [Fact]
        public async Task GetKitchenTask_ReturnsOk_WithListOfTasks()
        {
            // Arrange
            var tasks = new List<KitchenTaskDTO>
            {
                new KitchenTaskDTO
                {
                    Id = Guid.NewGuid(),
                    Description = "Preparar desayuno",
                    Status = "PENDING",
                    Kitchener = "JUAN",
                    PreparationDate = new DateTime(2025, 6, 26, 8, 30, 0)
                },
                new KitchenTaskDTO
                {
                    Id = Guid.NewGuid(),
                    Description = "Hornear pan",
                    Status = "IN_PROGRESS",
                    Kitchener = "MARIA",
                    PreparationDate = new DateTime(2025, 6, 26, 9, 0, 0)
                }
            };
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetKitchenTaskQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tasks, okResult.Value);
        }

        [Fact]
        public async Task GetKitchenTask_Returns500_WhenExceptionThrown()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetKitchenTaskQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error al obtener tareas"));

            // Act
            var result = await _controller.GetKitchenTask();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Error al obtener tareas", objectResult.Value);
        }
    }

}
