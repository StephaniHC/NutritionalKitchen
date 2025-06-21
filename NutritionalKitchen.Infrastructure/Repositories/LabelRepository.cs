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

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Label?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Label label)
        {
            throw new NotImplementedException();
        }
    }
}
