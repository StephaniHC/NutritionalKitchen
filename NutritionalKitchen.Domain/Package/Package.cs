using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public class Package : AggregateRoot
    { 
        public string Status { get; private set; }
        public Guid LabelId { get; private set; }
        public Package(string status, Guid labelId) : base(Guid.NewGuid())
        {
            Status = status; 
            LabelId = labelId;
        }
         
    }
}
