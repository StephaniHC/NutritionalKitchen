using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.WebApi
{
    public class HomeControllerTest
    {
        [Fact]
        public void Get_ReturnsRedirectToSwagger()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Get();

            // Assert
            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/swagger", redirectResult.Url);
        }
    }
}
