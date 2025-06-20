using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
{
    [Table("recipePreparation")]
    public class RecipePreparationStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("RecipeName")]
        [StringLength(100)]
        public string RecipeName { get; set; }

        [Column("Detail")]
        [StringLength(500)]
        public string Detail { get; set; }

        [Column("PreparationDate")]
        [Required]
        public DateTime PreparationDate { get; set; }

        [Column("PatientId")]
        [Required]
        public Guid PatientId { get; set; }
    }
}
