using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public interface IRecipePreparationRepository : IRepository<RecipePreparation>
    {
        Task UpdateAsync(RecipePreparation recipePreparation);
        Task DeleteAsync(Guid id);
    }
}
