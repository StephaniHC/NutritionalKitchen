using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.RecipePreparation.GetRecipe;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.Handlers
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, IEnumerable<RecipeDTO>>
    {
        private readonly StoredDbContext _dbContext;

        public GetRecipeQueryHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RecipeDTO>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Recipe.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(r => r.Name.Contains(request.SearchTerm));
            }

            var recipes = await query
                .Select(r => new RecipeDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                })
                .ToListAsync(cancellationToken);

            return recipes;
        }
    }
}
