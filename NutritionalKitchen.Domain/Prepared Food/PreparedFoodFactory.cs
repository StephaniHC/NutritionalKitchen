using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.PreparedFood
{
    public class PreparedFoodFactory : IPreparedFoodFactory
    {
        public PreparedFood Create(Guid idKitchenTask)
        {
            PreparedFood preparedFood = new PreparedFood(idKitchenTask);
            return preparedFood;
        }
    }
}
