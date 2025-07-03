using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public interface IRecipeFactory
    {
        Recipe Create(Guid id, string name, string description);
    }
}
