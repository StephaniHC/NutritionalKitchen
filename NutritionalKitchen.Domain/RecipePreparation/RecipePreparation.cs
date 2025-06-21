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
        public string RecipeName { get; private set; }
        public string Detail { get; private set; }
        public DateTime PreparationDate { get; private set; }
        public Guid PatientId { get; private set; }
        public RecipePreparation(string recipeName, string detail, DateTime preparationDate, Guid patientId) : base(Guid.NewGuid())
        {
            RecipeName = recipeName;
            Detail = detail;
            PreparationDate = preparationDate;
            PatientId = patientId;
        }
    }
}
