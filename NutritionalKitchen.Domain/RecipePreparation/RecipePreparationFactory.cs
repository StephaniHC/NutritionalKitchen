using NutritionalKitchen.Domain.KitchenTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public class RecipePreparationFactory : IRecipePreparationFactory
    {
        public RecipePreparation Create(string recipeName, string detail, DateTime preparationDate, Guid patientId)
        { 
            RecipePreparation recipePreparation = new RecipePreparation(recipeName, detail, preparationDate, patientId);
            return recipePreparation;
        }
    }
}
