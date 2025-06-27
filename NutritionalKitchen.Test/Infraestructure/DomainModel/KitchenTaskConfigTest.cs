using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Infrastructure.DomainModel.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Infraestructure.DomainModel
{
    public class KitchenTaskConfigTest
    {
        [Fact]
        public void KitchenTaskConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange: Creamos el ModelBuilder con las convenciones por defecto
            var modelBuilder = new ModelBuilder(new ConventionSet());

            // Creamos instancia de KitchenTaskConfig
            var config = new KitchenTaskConfig();

            // Act: Aplicamos la configuración a la entidad KitchenTask
            config.Configure(modelBuilder.Entity<KitchenTask>());

            // Assert: Obtenemos metadata de la entidad para validar
            var entityType = modelBuilder.Model.FindEntityType(typeof(KitchenTask));

            // Validaciones básicas
            Assert.NotNull(entityType);
            Assert.Equal("KitchenTask", entityType.GetTableName());

            var idProperty = entityType.FindProperty("Id");
            Assert.NotNull(idProperty);
            Assert.Equal("Id", idProperty.Name);

            var descriptionProperty = entityType.FindProperty("Description");
            Assert.NotNull(descriptionProperty);
            Assert.Equal("Description", descriptionProperty.Name);

            var statusProperty = entityType.FindProperty("Status");
            Assert.NotNull(statusProperty);
            Assert.Equal("Status", statusProperty.Name);

            var kitchenerProperty = entityType.FindProperty("Kitchener");
            Assert.NotNull(kitchenerProperty);
            Assert.Equal("Kitchener", kitchenerProperty.Name);

            var preparationDateProperty = entityType.FindProperty("PreparationDate");
            Assert.NotNull(preparationDateProperty);
            Assert.Equal("PreparationDate", preparationDateProperty.Name);
        }
    }
}
