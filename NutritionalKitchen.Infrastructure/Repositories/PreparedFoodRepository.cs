using NutritionalKitchen.Domain.Package;
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
    }
}
