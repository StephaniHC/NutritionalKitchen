using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.RecipePreparation;
using NutritionalKitchen.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DomainDbContext _dbContext;

        public RecipeRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Recipe entity)
        {
            await _dbContext.Recipe.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Recipe.Remove(obj);
        }

        public async Task<Recipe?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            return await _dbContext.Recipe.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Recipe recipe)
        {
            _dbContext.Recipe.Update(recipe);

            return Task.CompletedTask;
        }
    }
}
