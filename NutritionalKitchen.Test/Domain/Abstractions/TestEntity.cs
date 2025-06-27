using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Abstractions
{
    public class TestEntity : Entity
    {
        public TestEntity(Guid id) : base(id) { }
        public TestEntity() : base() { }
    }
}
