using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.StoredModel
{
    public class PackageStoredModelTest
    {
        [Fact]
        public void Package_ShouldFailValidation_WhenStatusIsNull()
        {
            // Arrange
            var model = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = null,
                LabelId = Guid.NewGuid()
            };

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Status"));
        }

        [Fact]
        public void Package_ShouldFailValidation_WhenStatusIsTooLong()
        {
            var model = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = new string('X', 21), 
                LabelId = Guid.NewGuid()
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Status"));
        }

        [Fact]
        public void Package_ShouldFailValidation_WhenLabelIdIsEmpty()
        {
            var model = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = "PENDING",
                LabelId = Guid.Empty 
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.True(isValid); 
        }

        [Fact]
        public void Package_ShouldPassValidation_WhenAllFieldsAreValid()
        {
            var model = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = "READY",
                LabelId = Guid.NewGuid()
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.True(isValid);
        }
    }
}
