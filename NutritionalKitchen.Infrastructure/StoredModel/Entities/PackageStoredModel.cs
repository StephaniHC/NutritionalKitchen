using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
{
    [Table("Package")]
    public class PackageStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; } 

        [Column("Status")]
        [StringLength(20)]
        [Required]
        public string Status { get; set; }

        [Column("LabelId")]
        [Required]
        public Guid LabelId { get; set; }
    }
}
