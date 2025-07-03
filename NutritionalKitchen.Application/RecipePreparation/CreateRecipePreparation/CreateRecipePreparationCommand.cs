using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation
{  
    public record CreateRecipePreparationCommand(Guid recipeId, string detail, string mealTime, DateTime preparationDate, Guid patientId) : IRequest<Guid>;

}
