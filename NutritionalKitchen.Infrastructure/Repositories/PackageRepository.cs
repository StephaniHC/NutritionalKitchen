using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DomainDbContext _dbContext;

        public PackageRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Package entity)
        {
            await _dbContext.Package.AddAsync(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Package?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Package package)
        {
            throw new NotImplementedException();
        }
    } 
}
