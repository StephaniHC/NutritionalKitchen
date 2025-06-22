using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.Package.GetPackage;
using NutritionalKitchen.Infrastructure.StoredModel;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetPackageHandler : IRequestHandler<GetPackageQuery, IEnumerable<PackageDTO>>
    {
        private readonly StoredDbContext _dbContext;
        public GetPackageHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PackageDTO>> Handle(GetPackageQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Package.AsNoTracking().
            Select(p => new PackageDTO()
            {
                Id = p.Id,
                Status = p.Status,
                LabelId = p.LabelId
            }).
            ToListAsync(cancellationToken);
        }
    }
}
