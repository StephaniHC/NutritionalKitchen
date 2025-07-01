using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.Labeled
{
    public record DeliberyUpdate : IntegrationMessage
    {
        public Guid ContractId { get; set; }
        public Guid DeliveryDayId { get; set; } 
        public string? Street { get; set; }
        public int Number { get; set; }
        public Guid Id { get; set; }
        public DateTime OcurredOn { get; set; }

        public DeliberyUpdate(
            Guid contractId,
            Guid deliveryDayId,
            Guid id,
            string? street = null,
            int number = 0,
            DateTime? ocurredOn = null,
            string? correlationId = null,
            string? source = null
        ) : base(correlationId, source)
        {
            ContractId = contractId;
            DeliveryDayId = deliveryDayId;
            Id = id;
            Street = street;
            Number = number;
            OcurredOn = ocurredOn ?? DateTime.UtcNow;
        }
    }
}
