using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.StoredModel
{
    public class RecipePreparationStoredModelTest
    {
        [Fact]
        public void RecipePreparation_ShouldFail_ManualValidation()
        {
            // Arrange
            var model = new RecipePreparationStoredModel
            {
                Id = Guid.NewGuid(),
                RecipeName = "Ensalada",
                Detail = "Verduras frescas",
                PreparationDate = DateTime.Today,
                PatientId = Guid.NewGuid()
            };

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.NotEqual(Guid.Empty, model.PatientId);
        }


        [Fact]
        public void Should_PassValidation_When_AllFields_AreValid()
        {
            // Arrange
            var model = new RecipePreparationStoredModel
            {
                Id = Guid.NewGuid(),
                RecipeName = "Sopa de pollo",
                Detail = "Receta casera",
                PreparationDate = DateTime.Today,
                PatientId = Guid.NewGuid()
            };

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.True(isValid);
        }
    }
}
