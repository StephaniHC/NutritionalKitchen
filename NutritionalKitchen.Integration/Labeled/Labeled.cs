using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.Labeled
{
    public record Labeled : IntegrationMessage
    {
        public Guid ContractId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public List<DeliveryDays> DeliveryDays { get; set; } = new(); 
        public Guid Id { get; set; }
        public DateTime OcurredOn { get; set; } 
        public Labeled(
            Guid contractId,
            Guid patientId,
            Guid id,
            DateTime? startDate = null,
            DateTime? endDate = default,
            List<DeliveryDays>? deliveryDays = null,
            DateTime? ocurredOn = null,
            string? correlationId = null,
            string? source = null
        ) : base(correlationId, source)
        {
            ContractId = contractId;
            PatientId = patientId;
            Id = id;
            StartDate = startDate ?? DateTime.UtcNow;
            EndDate = endDate ?? DateTime.UtcNow;
            DeliveryDays = deliveryDays ?? new List<DeliveryDays>();
            OcurredOn = ocurredOn ?? DateTime.UtcNow;
        }
    }
}
