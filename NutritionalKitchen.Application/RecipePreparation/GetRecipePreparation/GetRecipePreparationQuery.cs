using MediatR;
using NutritionalKitchen.Application.PreparedFood.GetPreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation
{ 
    public record GetRecipePreparationQuery(string SearchTerm) : IRequest<IEnumerable<RecipePreparationDTO>>;
}
