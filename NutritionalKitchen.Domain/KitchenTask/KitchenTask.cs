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
        public string Description { get; private set; }
        public string Status { get; private set; }
        public string Kitchener { get; private set; }
        public DateTime PreparationDate { get; private set; }
        public KitchenTask(string description, string status, string kitchener, DateTime preparationDate) : base(Guid.NewGuid())
        {
            Description = description;
            Status = status;
            Kitchener = kitchener;
            PreparationDate = preparationDate;
        }
    }
}
