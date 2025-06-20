using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.PreparedFood
{
    public class PreparedFood : AggregateRoot
    {
        public PreparedFood(Guid id) : base(id)
        {
        }
    }
}
