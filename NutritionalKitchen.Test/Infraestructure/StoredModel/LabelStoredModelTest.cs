using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.StoredModel
{
    public class LabelStoredModelTest
    {
        [Fact]
        public void Label_ShouldFailValidation_WhenRequiredFieldsAreMissing()
        {
            // Arrange
            var model = new LabelStoredModel
            {
                Id = Guid.NewGuid(),
                ProductionDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddDays(10),
                DeliberyDate = DateTime.Today,
                Detail = "Detalle válido",
                Address = "Avenida",
                ContractId = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DeliberyId = Guid.NewGuid(),
                Status = true
            };

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.True(isValid); 
             
            Assert.NotEqual(Guid.Empty, model.ContractId);
            Assert.NotEqual(Guid.Empty, model.PatientId);
        }
         
        [Fact]
        public void Label_ShouldFailValidation_WhenDetailIsTooLong()
        {
            var model = new LabelStoredModel
            {
                Id = Guid.NewGuid(),
                ProductionDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddDays(10),
                DeliberyDate = DateTime.Today,
                Detail = new string('X', 501),
                Address = "Calle 1",
                ContractId = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DeliberyId = Guid.NewGuid(),
                Status = true
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Detail"));
        }

        [Fact]
        public void Label_ShouldFailValidation_WhenAddressIsTooLong()
        {
            var model = new LabelStoredModel
            {
                Id = Guid.NewGuid(),
                ProductionDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddDays(10),
                DeliberyDate = DateTime.Today,
                Detail = "Descripción",
                Address = new string('A', 257),
                ContractId = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DeliberyId = Guid.NewGuid(),
                Status = true
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Address"));
        }

        [Fact]
        public void Label_ShouldPassValidation_WhenAllFieldsAreValid()
        {
            var model = new LabelStoredModel
            {
                Id = Guid.NewGuid(),
                ProductionDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddDays(5),
                DeliberyDate = DateTime.Today.AddDays(1),
                Detail = "Etiqueta válida",
                Address = "Calle Falsa 123",
                ContractId = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DeliberyId = Guid.NewGuid(),
                Status = true
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.True(isValid);
        }
    }
}
