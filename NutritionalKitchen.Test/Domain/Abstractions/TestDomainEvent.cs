using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Abstractions
{
    public record TestDomainEvent : DomainEvent
    {
        public string Message { get; init; }

        public TestDomainEvent(string message)
        {
            Message = message;
        }
    }
}
