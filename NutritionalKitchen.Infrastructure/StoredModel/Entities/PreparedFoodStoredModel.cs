using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
{
    [Table("PreparedFood")]
    public class PreparedFoodStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("IdKitchenTask")]
        [Required]
        public Guid IdKitchenTask { get; set; }

        [Column("IdRecipePreparation")]
        [Required]
        public Guid IdRecipePreparation { get; set; }

        [Column("RecipePreparationDate")]
        [Required]
        public DateTime RecipePreparationDate { get; set; }

        [Column("Status")]
        [Required]
        public string Status { get; set; }

        [Column("Recipe")]
        public string Recipe { get; set; }

        [Column("Detail")]
        public string Detail { get; set; }

        [Column("PatientId")]
        [Required]
        public Guid PatientId { get; set; }

        [Column("LabelId")]
        public Guid? LabelId { get; set; }

    }
}
