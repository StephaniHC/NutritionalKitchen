using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public class RecipePreparation : AggregateRoot
    {
        public Guid RecipeId { get; private set; }
        public string Detail { get; private set; }
        public string MealTime { get; private set; }
        public DateTime PreparationDate { get; private set; }
        public Guid PatientId { get; private set; }
        public RecipePreparation(Guid recipeId, string detail, string mealTime, DateTime preparationDate, Guid patientId) : base(Guid.NewGuid())
        {
            RecipeId = recipeId;
            Detail = detail;
            MealTime = mealTime;
            PreparationDate = preparationDate;
            PatientId = patientId;
        }
    }
}
