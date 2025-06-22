using MediatR;
using Microsoft.EntityFrameworkCore; 
using NutritionalKitchen.Application.Label.GetLabel;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetLabelHandler : IRequestHandler<GetLabelQuery, IEnumerable<LabelDTO>>
    {
        private readonly StoredDbContext _dbContext;
        public GetLabelHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LabelDTO>> Handle(GetLabelQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Label.AsNoTracking().
            Select(l => new LabelDTO()
            {
                Id = l.Id,
                ProductionDate = l.ProductionDate,
                ExpirationDate = l.ExpirationDate,
                DeliberyDate = l.DeliberyDate,
                Detail = l.Detail,
                Address = l.Address,
                ContractId = l.ContractId,
                PatientId = l.PatientId
            }).
            ToListAsync(cancellationToken);
        }
    }
}
