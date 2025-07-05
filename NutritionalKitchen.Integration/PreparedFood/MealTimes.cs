using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.PreparedFood
{
    public record MealTimes
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public Guid RecipeId { get; set; }

        public MealTimes( 
            Guid recipeId,
            int number,
            string? type = null,
            DateTime? date = null
        )
        { 
            RecipeId = recipeId;
            Number = number;
            Type = type;
            Date = date ?? DateTime.UtcNow;
        }
    }
}
