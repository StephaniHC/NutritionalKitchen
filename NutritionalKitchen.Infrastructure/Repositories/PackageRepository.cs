using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Package.Remove(obj);
        }

        public async Task<Package?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            return await _dbContext.Package.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Package package)
        {
            _dbContext.Package.Update(package);

            return Task.CompletedTask;
        }
    } 
}
