using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Label
{
    public class Label : AggregateRoot
    {
        public Guid Id { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public DateTime DeliberyDate { get; private set; }
        public string Detail { get; private set; }
        public string Address { get; private set; }
        public Guid ContractId { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DeliberyId { get; private set; }
        public bool Status { get; private set; }
        public Label(Guid id, DateTime productionDate, DateTime expirationDate, DateTime deliberyDate, string detail, string address, Guid contractId, Guid patientId, Guid deliberyId, bool status) : base(Guid.NewGuid())
        {
            Id = id;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            DeliberyDate = deliberyDate;
            Detail = detail;
            Address = address;
            ContractId = contractId;
            PatientId = patientId;
            DeliberyId = deliberyId;
            Status = status;
        }
        public void Update(string address)
        {  
            Address = address;
        }
    }
}
