using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.PreparedFood.CreatePreparedFood
{
    public record CreatePreparedFoodCommand(
        Guid idKitchenTask,
        Guid idRecipePreparation,
        DateTime recipePreparationDate,
        string status,
        string recipe,
        string detail,
        Guid patientId,
        Guid labelId
    ) : IRequest<Guid>;
}
