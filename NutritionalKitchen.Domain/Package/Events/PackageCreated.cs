using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package.Events
{ 
    public record PackageCreated(Guid RecipeId, string status, Guid labelId) : DomainEvent
    {
        public PackageCreated() : this(Guid.Empty, string.Empty, Guid.Empty)
        {
        }
    }
}
