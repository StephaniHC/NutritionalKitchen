using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Repositories
{
    public class KitchenTaskRepository : IKitchenTaskRepository
    {
        private readonly DomainDbContext _dbContext;

        public KitchenTaskRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(KitchenTask entity)
        {
            await _dbContext.KitchenTask.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.KitchenTask.Remove(obj);
        }

        public async Task<KitchenTask?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            return await _dbContext.KitchenTask.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(KitchenTask kitchenTask)
        {
            _dbContext.KitchenTask.Update(kitchenTask);

            return Task.CompletedTask;
        }
    }
}
