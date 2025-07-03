using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public class RecipeFactory : IRecipeFactory
    {
        public Recipe Create(Guid id, string name, string description)
        {
            Recipe recipe = new Recipe(id, name, description);
            return recipe;
        }
    }
}
