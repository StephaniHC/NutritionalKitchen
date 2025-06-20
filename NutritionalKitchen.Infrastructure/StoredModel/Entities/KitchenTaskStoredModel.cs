using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
{
    [Table("kitchenTask")]
    public class KitchenTaskStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("Status")]
        [StringLength(20)]
        [Required]
        public string Status { get; set; }
         
        [Column("Kitchener")]
        [StringLength(100)]
        public string Kitchener { get; set; }

        [Column("PreparationDate")]
        [Required]
        public DateTime PreparationDate { get; set; }

    }
}
