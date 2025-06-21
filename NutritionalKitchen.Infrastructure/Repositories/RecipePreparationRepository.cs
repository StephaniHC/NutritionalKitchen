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

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RecipePreparation?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RecipePreparation recipePreparation)
        {
            throw new NotImplementedException();
        }
    }
}
