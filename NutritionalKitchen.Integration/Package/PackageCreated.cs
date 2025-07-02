using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.Package
{
    public record PackageCreated : IntegrationMessage
    {
        public Guid PackageId { get; set; }
        public string? Status { get; set; }

        public PackageCreated(Guid packageId, string? status, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            PackageId = packageId;
            Status = status;
        }
    }
}
