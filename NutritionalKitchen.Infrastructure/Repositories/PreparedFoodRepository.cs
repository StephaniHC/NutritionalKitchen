using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.PreparedFood; 
using NutritionalKitchen.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Repositories
{
    public class PreparedFoodRepository : IPreparedFoodRepository
    {
        private readonly DomainDbContext _dbContext;

        public PreparedFoodRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PreparedFood entity)
        {
            await _dbContext.PreparedFood.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.PreparedFood.Remove(obj);
        }

        public async Task<PreparedFood?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            return await _dbContext.PreparedFood.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(PreparedFood preparedFood)
        {
            _dbContext.PreparedFood.Update(preparedFood);

            return Task.CompletedTask;
        }
        public async Task<IEnumerable<PreparedFood>> GetByPreparationDateAsync(DateTime preparationDate)
        {
            return await _dbContext.PreparedFood
                .Where(p => p.RecipePreparationDate.Date == preparationDate.Date)
                .ToListAsync();
        }

    }
}
