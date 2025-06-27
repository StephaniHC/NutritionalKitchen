using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.StoredModel
{
    public class PreparedFoodStoredModelTEst
    {
        [Fact]
        public void PreparedFood_ShouldPassValidation_WhenAllFieldsAreValid()
        {
            // Arrange
            var model = new PreparedFoodStoredModel
            {
                Id = Guid.NewGuid(),
                IdKitchenTask = Guid.NewGuid()
            };

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void PreparedFood_ShouldPassValidation_WhenIdKitchenTaskIsValid()
        {
            // Arrange
            var model = new PreparedFoodStoredModel
            {
                Id = Guid.NewGuid(),
                IdKitchenTask = Guid.NewGuid()
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
