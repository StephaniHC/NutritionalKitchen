using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.CreateRecipe
{ 
    public record CreateRecipeCommand(Guid id, string name, string description) : IRequest<Guid>;
}
