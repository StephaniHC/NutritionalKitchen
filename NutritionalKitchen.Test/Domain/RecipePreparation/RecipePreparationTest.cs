using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.RecipePreparation
{
    public class RecipePreparationTest
    {
        [Fact]
        public void Constructor_ShouldInitializeAllProperties()
        {
            // Arrange
            var recipeName = "Sopa de verduras";
            var detail = "Para dieta baja en sodio";
            var preparationDate = new DateTime(2025, 6, 26);
            var patientId = Guid.NewGuid();

            // Act
            var recipePreparation = new NutritionalKitchen.Domain.RecipePreparation.RecipePreparation(patientId, patientId, recipeName, detail, preparationDate, patientId);

            // Assert
            Assert.NotNull(recipePreparation); 
            Assert.Equal(detail, recipePreparation.Detail);
            Assert.Equal(preparationDate, recipePreparation.PreparationDate);
            Assert.Equal(patientId, recipePreparation.PatientId);
            Assert.NotEqual(Guid.Empty, recipePreparation.Id);
        }
    }
}
