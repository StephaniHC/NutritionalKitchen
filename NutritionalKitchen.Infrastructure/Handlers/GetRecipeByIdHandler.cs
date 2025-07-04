using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.RecipePreparation.GetRecipe;
using NutritionalKitchen.Infrastructure.StoredModel;
using System;
using System.Threading;
using System.Threading.Tasks;

public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDTO>
{
    private readonly StoredDbContext _dbContext;

    public GetRecipeByIdHandler(StoredDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RecipeDTO> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var recipe = await _dbContext.Recipe
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (recipe == null)
            return null; 

        return new RecipeDTO
        {
            Id = recipe.Id,
            Name = recipe.Name, 
            Description = recipe.Description
        };
    }
}
