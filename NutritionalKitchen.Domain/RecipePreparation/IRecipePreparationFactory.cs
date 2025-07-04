using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public interface IRecipePreparationFactory
    {
        RecipePreparation Create(Guid id, Guid recipeId, string detail, string mealTime, DateTime preparationDate, Guid patientId);
    }
}
