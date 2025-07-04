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
        public RecipePreparation Create(Guid id, Guid recipeId, string detail, string mealTime, DateTime preparationDate, Guid patientId)
        { 
            RecipePreparation recipePreparation = new RecipePreparation(id, recipeId, detail, mealTime, preparationDate, patientId);
            return recipePreparation;
        }
    }
} 