using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation
{  
    public record CreateRecipePreparationCommand(string recipeName, string detail, DateTime preparationDate, Guid patientId) : IRequest<Guid>;

}
