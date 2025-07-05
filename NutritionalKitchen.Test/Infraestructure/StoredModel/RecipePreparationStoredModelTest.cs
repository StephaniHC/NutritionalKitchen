using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructure.StoredModel
{
    public class RecipePreparationStoredModelTest
    {
        [Fact]
        public void RecipePreparation_ShouldFail_ManualValidation_WhenRecipeIdIsMissing()
        {
            // Arrange
            var model = new RecipePreparationStoredModel
            {
                Id = Guid.NewGuid(),
                // RecipeId = missing to simulate invalid model
                Detail = "Verduras frescas",
                PreparationDate = DateTime.Today,
                PatientId = Guid.NewGuid()
            };

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(RecipePreparationStoredModel.RecipeId)));
        }

        [Fact]
        public void Should_PassValidation_When_AllFields_AreValid()
        {
            // Arrange
            var model = new RecipePreparationStoredModel
            {
                Id = Guid.NewGuid(),
                RecipeId = Guid.NewGuid(),
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
            Assert.Empty(results);
        }
    }
}
