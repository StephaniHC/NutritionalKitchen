using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.PreparedFood
{
    public class PreparedFoodFactory : IPreparedFoodFactory
    {
        public PreparedFood Create(Guid idKitchenTask, Guid idRecipePreparation, DateTime recipePreparationDate, string status, string recipe, string detail, Guid patientId)
        {
            PreparedFood preparedFood = new PreparedFood(idKitchenTask, idRecipePreparation, recipePreparationDate, status, recipe, detail, patientId, null);
            return preparedFood;
        }
    }
}
