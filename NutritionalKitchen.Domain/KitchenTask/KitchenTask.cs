using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenTask
{
    public class KitchenTask : AggregateRoot
    {
        public string Kitchener { get; private set; }
        public DateTime PreparationDate { get; private set; }
        public KitchenTask(string kitchener, DateTime preparationDate) : base(Guid.NewGuid())
        {
            Kitchener = kitchener;
            PreparationDate = preparationDate;
        }
    }
}
