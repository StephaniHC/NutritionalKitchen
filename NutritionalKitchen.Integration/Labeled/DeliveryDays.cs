using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.Labeled
{
    public record DeliveryDays
    { 
        public Guid ContractId { get; set; }
        public DateTime Date { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public Guid Id { get; set; } 

        public DeliveryDays(
            Guid contractId,
            Guid id,
            DateTime? date = null,
            string? street = null,
            int number = 0
        )
        {
            ContractId = contractId;
            Id = id;
            Date = date ?? DateTime.UtcNow;
            Street = street;
            Number = number; 
        }
    }
}
