using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.Package
{
    public record Package : IntegrationMessage
    {
        public Guid LabelId { get; set; }

        public Package(Guid labelId, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            LabelId = labelId;
        }
    }
}
