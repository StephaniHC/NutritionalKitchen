using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.RecipePreparation
{
    public class RecipePreparationFactoryTest
    {
        [Fact]
        public void Create_ShouldReturnRecipePreparation_WithCorrectProperties()
        {
            // Arrange
            var factory = new RecipePreparationFactory();
            var recipeName = "Ensalada de quinoa";
            var detail = "Sin sal, para hipertensión";
            var preparationDate = new DateTime(2025, 6, 26);
            var patientId = Guid.NewGuid();

            // Act
            var result = factory.Create(recipeName, detail, preparationDate, patientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(recipeName, result.RecipeName);
            Assert.Equal(detail, result.Detail);
            Assert.Equal(preparationDate, result.PreparationDate);
            Assert.Equal(patientId, result.PatientId);
        }
    }
}
