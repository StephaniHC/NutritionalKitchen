﻿using MediatR; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.GetRecipe
{
    public record GetRecipeQuery (string SearchTerm) : IRequest<IEnumerable<RecipeDTO>>;

    public record GetRecipeByIdQuery(Guid Id) : IRequest<RecipeDTO>;
}
