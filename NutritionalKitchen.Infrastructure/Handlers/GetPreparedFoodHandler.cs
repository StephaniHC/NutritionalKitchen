using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.PreparedFood.GetPreparedFood;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetPreparedFoodHandler : IRequestHandler<GetPreparedFoodQuery, IEnumerable<PreparedFoodDTO>>
    {
        private readonly StoredDbContext _dbContext;
        public GetPreparedFoodHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PreparedFoodDTO>> Handle(GetPreparedFoodQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.PreparedFood.AsNoTracking().
            Select(p => new PreparedFoodDTO()
            {
                Id = p.Id,
                IdKitchenTask = p.IdKitchenTask,
                IdRecipePreparation = p.IdRecipePreparation,
                RecipePreparationDate = p.RecipePreparationDate,
                PatientId = p.PatientId
            }).
            ToListAsync(cancellationToken);
        }
    }
}
