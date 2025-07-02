using NutritionalKitchen.Integration.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Integration
{
    public class RecipePreparationTest
    {
        [Fact]
        public void Constructor_ShouldAssign_AllProperties()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var name = "Ensalada de frutas";
            var description = "Mezcla de frutas naturales";
            var createdAt = new DateTime(2025, 7, 2, 10, 0, 0, DateTimeKind.Utc);
            var correlationId = "corr-xyz";
            var source = "KitchenModule";

            // Act
            var recipe = new RecipePreparation(recipeId, id, name, description, createdAt, correlationId, source);

            // Assert
            Assert.Equal(recipeId, recipe.RecipeId);
            Assert.Equal(id, recipe.Id);
            Assert.Equal(name, recipe.Name);
            Assert.Equal(description, recipe.Description);
            Assert.Equal(createdAt, recipe.CreatedAt);
            Assert.Equal(correlationId, recipe.CorrelationId);
            Assert.Equal(source, recipe.Source);
        }

        [Fact]
        public void Constructor_ShouldSetCreatedAtToUtcNow_WhenNotProvided()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var before = DateTime.UtcNow;

            // Act
            var recipe = new RecipePreparation(recipeId, id);

            var after = DateTime.UtcNow;

            // Assert
            Assert.True(recipe.CreatedAt >= before && recipe.CreatedAt <= after);
        }

        [Fact]
        public void Constructor_ShouldHandleNullOptionals()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var id = Guid.NewGuid();

            // Act
            var recipe = new RecipePreparation(recipeId, id, null, null, null, null, null);

            // Assert
            Assert.Equal(recipeId, recipe.RecipeId);
            Assert.Equal(id, recipe.Id);
            Assert.Null(recipe.Name);
            Assert.Null(recipe.Description);
            Assert.Null(recipe.CorrelationId);
            Assert.Null(recipe.Source);
        }
    }
}
