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
    } 
}
