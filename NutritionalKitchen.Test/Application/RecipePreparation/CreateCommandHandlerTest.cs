using Moq;
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Application.RecipePreparation
{
    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreateRecipePreparation_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var recipePreparationId = Guid.NewGuid();
            var recipeName = "Ensalada de frutas";
            var detail = "Preparar con fruta fresca";
            var preparationDate = DateTime.Today;
            var patientId = Guid.NewGuid();

            var command = new CreateRecipePreparationCommand(
                recipeName,
                detail,
                preparationDate,
                patientId
            );

            var mockFactory = new Mock<IRecipePreparationFactory>();
            var mockRepository = new Mock<IRecipePreparationRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdRecipePreparation = new NutritionalKitchen.Domain.RecipePreparation.RecipePreparation( 
                recipeName,
                detail,
                preparationDate,
                patientId
            );

            mockFactory
                .Setup(f => f.Create(recipeName, detail, preparationDate, patientId))
                .Returns(createdRecipePreparation);

            var handler = new CreateCommandHandler(
                mockFactory.Object,
                mockRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert 
            mockFactory.Verify(f => f.Create(recipeName, detail, preparationDate, patientId), Times.Once);
            mockRepository.Verify(r => r.AddAsync(createdRecipePreparation), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
