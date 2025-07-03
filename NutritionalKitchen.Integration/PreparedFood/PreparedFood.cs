using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.PreparedFood
{
    public record PreparedFood : IntegrationMessage
    {
        public Guid MealPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Goal { get; set; }
        public int DailyCalories { get; set; }
        public int DailyProtein { get; set; }
        public int DailyCarbohydrates { get; set; }
        public int DailyFats { get; set; }
        public Guid NutritionistId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DiagnosticId { get; set; }
        public List<MealTimes> MealTimes { get; set; } = new();

        public PreparedFood(
            Guid mealPlanId,
            string? name,
            string? description,
            string? goal,
            int dailyCalories,
            int dailyProtein,
            int dailyCarbohydrates,
            int dailyFats,
            Guid nutritionistId,
            Guid patientId,
            Guid diagnosticId,
            List<MealTimes>? mealTimes = null,
            string? correlationId = null,
            string? source = null
        ) : base(correlationId, source)
        {
            MealPlanId = mealPlanId;
            Name = name;
            Description = description;
            Goal = goal;
            DailyCalories = dailyCalories;
            DailyProtein = dailyProtein;
            DailyCarbohydrates = dailyCarbohydrates;
            DailyFats = dailyFats;
            NutritionistId = nutritionistId;
            PatientId = patientId;
            DiagnosticId = diagnosticId;
            MealTimes = mealTimes ?? new List<MealTimes>();
        }
    }
}