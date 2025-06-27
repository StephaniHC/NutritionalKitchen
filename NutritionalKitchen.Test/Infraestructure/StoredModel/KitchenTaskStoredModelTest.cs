using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.StoredModel
{
    public class KitchenTaskStoredModelTest
    {
        [Fact]
        public void KitchenTask_ShouldFailValidation_WhenStatusIsNull()
        {
            // Arrange
            var model = new KitchenTaskStoredModel
            {
                Id = Guid.NewGuid(),
                Description = "Valid description",
                Status = null,
                Kitchener = "Pedro",
                PreparationDate = DateTime.Today
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Status"));
        }

        [Fact]
        public void KitchenTask_ShouldFailValidation_WhenStatusExceedsMaxLength()
        {
            var model = new KitchenTaskStoredModel
            {
                Id = Guid.NewGuid(),
                Description = "Valid description",
                Status = new string('X', 21),
                Kitchener = "Pedro",
                PreparationDate = DateTime.Today
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Status"));
        }

        [Fact]
        public void KitchenTask_ShouldFailValidation_WhenPreparationDateIsDefault()
        {
            var model = new KitchenTaskStoredModel
            {
                Id = Guid.NewGuid(),
                Description = "Some desc",
                Status = "PENDING",
                Kitchener = "JUAN",
                PreparationDate = default 
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void KitchenTask_ShouldPassValidation_WhenAllFieldsAreValid()
        {
            var model = new KitchenTaskStoredModel
            {
                Id = Guid.NewGuid(),
                Description = "Preparar sopa",
                Status = "PENDING",
                Kitchener = "Ana",
                PreparationDate = DateTime.Today
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void KitchenTask_ShouldFailValidation_WhenDescriptionIsTooLong()
        {
            var model = new KitchenTaskStoredModel
            {
                Id = Guid.NewGuid(),
                Description = new string('D', 501),
                Status = "PENDING",
                Kitchener = "Ana",
                PreparationDate = DateTime.Today
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Description"));
        }

        [Fact]
        public void KitchenTask_ShouldFailValidation_WhenKitchenerIsTooLong()
        {
            var model = new KitchenTaskStoredModel
            {
                Id = Guid.NewGuid(),
                Description = "Valida",
                Status = "PENDING",
                Kitchener = new string('A', 101),
                PreparationDate = DateTime.Today
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Kitchener"));
        }
    }
}
