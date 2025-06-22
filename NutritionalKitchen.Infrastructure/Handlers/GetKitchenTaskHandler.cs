using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.KitchenTask.GetKitchenTask;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetKitchenTaskHandler : IRequestHandler<GetKitchenTaskQuery, IEnumerable<KitchenTaskDTO>>
    {
        private readonly StoredDbContext _dbContext;
        public GetKitchenTaskHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<KitchenTaskDTO>> Handle(GetKitchenTaskQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.KitchenTask.AsNoTracking().
            Select(k => new KitchenTaskDTO()
            {
                Id = k.Id,
                Description = k.Description,
                Status = k.Status,
                Kitchener = k.Kitchener,
                PreparationDate = k.PreparationDate
            }).
            ToListAsync(cancellationToken);
        }
    }
}
