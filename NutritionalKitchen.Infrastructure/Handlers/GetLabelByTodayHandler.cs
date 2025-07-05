using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.Label.GetLabel;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetLabelByTodayHandler : IRequestHandler<GetLabelByTodayQuery, IEnumerable<LabelDTO>>
    {
        private readonly StoredDbContext _dbContext;

        public GetLabelByTodayHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LabelDTO>> Handle(GetLabelByTodayQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;

            return await _dbContext.Label
                .AsNoTracking()
                .Where(l => l.ProductionDate.Date == today && l.PatientId == request.PatientId)
                .Select(l => new LabelDTO
                {
                    Id = l.Id,
                    ProductionDate = l.ProductionDate,
                    ExpirationDate = l.ExpirationDate,
                    DeliberyDate = l.DeliberyDate,
                    Detail = l.Detail,
                    Address = l.Address,
                    ContractId = l.ContractId,
                    PatientId = l.PatientId,
                    DeliberyId = l.DeliberyId,
                    Status = l.Status
                })
                .ToListAsync(cancellationToken);
        }
    }
}
