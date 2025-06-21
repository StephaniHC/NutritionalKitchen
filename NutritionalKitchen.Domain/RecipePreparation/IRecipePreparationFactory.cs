using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public interface IRecipePreparationFactory
    {
        RecipePreparation Create(string recipeName, string detail, DateTime preparationDate, Guid patientId);
    }
}
