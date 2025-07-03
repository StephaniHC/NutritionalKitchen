using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
{
    [Table("RecipePreparation")]
    public class RecipePreparationStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("RecipeId")]
        [Required]
        public Guid RecipeId { get; set; }

        [Column("Detail")]
        [StringLength(500)]
        public string Detail { get; set; }

        [Column("MealTime")]
        [StringLength(500)]
        public string MealTime { get; set; }

        [Column("PreparationDate")]
        [Required]
        public DateTime PreparationDate { get; set; }

        [Column("PatientId")]
        [Required]
        public Guid PatientId { get; set; }

    }
}
