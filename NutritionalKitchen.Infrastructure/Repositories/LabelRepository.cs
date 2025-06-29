using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly DomainDbContext _dbContext;

        public LabelRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Label entity)
        {
            await _dbContext.Label.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Label.Remove(obj);
        }

        public async Task<Label?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            return await _dbContext.Label.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Label label)
        {
            _dbContext.Label.Update(label);

            return Task.CompletedTask;
        } 
    }
}
