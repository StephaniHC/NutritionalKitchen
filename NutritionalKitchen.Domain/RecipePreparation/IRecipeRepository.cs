using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Guid id);
    }
}
