using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetRecipePreparationByTodayHandler : IRequestHandler<GetRecipePreparationByTodayQuery, IEnumerable<RecipePreparationDTO>>
    {
        private readonly StoredDbContext _dbContext;

        public GetRecipePreparationByTodayHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RecipePreparationDTO>> Handle(GetRecipePreparationByTodayQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;

            return await _dbContext.RecipePreparation
                .AsNoTracking()
                .Where(r => r.PreparationDate.Date == today)
                .Select(r => new RecipePreparationDTO
                {
                    Id = r.Id,
                    RecipeId = r.RecipeId,
                    Detail = r.Detail,
                    MealTime = r.MealTime,
                    PreparationDate = r.PreparationDate,
                    PatientId = r.PatientId
                })
                .ToListAsync(cancellationToken);
        }
    }
}
