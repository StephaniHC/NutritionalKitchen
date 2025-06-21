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
         
    }
}
