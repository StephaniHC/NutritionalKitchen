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

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<KitchenTask?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(KitchenTask kitchenTask)
        {
            throw new NotImplementedException();
        }
    }
}
