using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.PreparedFood
{
    public interface IPreparedFoodFactory
    {
        PreparedFood Create(Guid idKitchenTask, Guid idRecipePreparation, DateTime recipePreparationDate, string status, string recipe, string detail, Guid patientId);
    }
}
