using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Domain.RecipePreparation;
using NutritionalKitchen.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Repositories
{
    public class RecipePreparationRepository : IRecipePreparationRepository
    {
        private readonly DomainDbContext _dbContext;

        public RecipePreparationRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(RecipePreparation entity)
        {
            await _dbContext.RecipePreparation.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.RecipePreparation.Remove(obj);
        }

        public async Task<RecipePreparation?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            return await _dbContext.RecipePreparation.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(RecipePreparation recipePreparation)
        {
            _dbContext.RecipePreparation.Update(recipePreparation);

            return Task.CompletedTask;
        }
    }
}
