using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.GetLabel
{
    public class LabelDTO
    {
        public Guid Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime DeliberyDate { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }
        public Guid ContractId { get; set; }
        public Guid PatientId { get; set; }
    }
}
