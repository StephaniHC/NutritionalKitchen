using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.PreparedFood
{
    public class PreparedFood : AggregateRoot
    {
        public Guid IdKitchenTask { get; private set; }
        public Guid IdRecipePreparation { get; private set; }
        public DateTime RecipePreparationDate { get; private set; }
        public string Status { get; private set; }
        public string Recipe { get; private set; }
        public string Detail { get; private set; }
        public Guid PatientId { get; private set; } 
        public Guid? LabelId { get; private set; } 
        public PreparedFood(
            Guid idKitchenTask,
            Guid idRecipePreparation,
            DateTime recipePreparationDate,
            string status,
            string recipe,
            string detail,
            Guid patientId,
            Guid? labelId
        ) : base(Guid.NewGuid())
        {
            IdKitchenTask = idKitchenTask;
            IdRecipePreparation = idRecipePreparation;
            RecipePreparationDate = recipePreparationDate;
            Status = status;
            Recipe = recipe;
            Detail = detail;
            PatientId = patientId;
            LabelId = labelId;
        }
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }

    }
}
