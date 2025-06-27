using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Abstractions
{
    public class TestAggregateRoot : AggregateRoot
    {
        public TestAggregateRoot(Guid id) : base(id) { }
    }
}
