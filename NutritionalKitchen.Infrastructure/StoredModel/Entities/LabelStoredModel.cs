using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
{
    [Table("Label")]
    public class LabelStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("ProductionDate")]
        public DateTime ProductionDate { get; set; }

        [Column("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }

        [Column("DeliberyDate")]
        [Required]
        public DateTime DeliberyDate { get; set; }

        [Column("Detail")]
        [StringLength(500)]
        public string Detail { get; set; }

        [Column("Address")]
        [StringLength(256)]
        [Required]
        public string Address { get; set; }

        [Column("ContractId")]
        [Required]
        public Guid ContractId { get; set; }

        [Column("PatientId")]
        [Required]
        public Guid PatientId { get; set; }

    }
}
