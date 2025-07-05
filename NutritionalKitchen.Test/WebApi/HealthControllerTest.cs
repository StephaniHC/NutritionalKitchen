using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.WebApi.Controllers;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class HealthControllerTest
    {
        [Fact]
        public void GetHealth_ReturnsOkWithStatusOk()
        {
            // Arrange
            var controller = new HealthController();

            // Act
            var result = controller.GetHealth();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value as dynamic;

            Assert.NotNull(value);
            Assert.Equal("ok", (string)value.status);
        }
    }
}
