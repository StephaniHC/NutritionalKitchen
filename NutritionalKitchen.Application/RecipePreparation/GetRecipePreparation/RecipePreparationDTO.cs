using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation
{
    public class RecipePreparationDTO
    { 
        public Guid Id { get; set; } 
        public string RecipeName { get; set; } 
        public string Detail { get; set; } 
        public DateTime PreparationDate { get; set; } 
        public Guid PatientId { get; set; }
    }
}
