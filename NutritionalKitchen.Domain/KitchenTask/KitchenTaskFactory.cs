using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenTask
{
    public class KitchenTaskFactory : IKitchenTaskFactory
    {
        public KitchenTask Create(string kitchener, DateTime preparationDate)
        {
            KitchenTask kitchenTask = new KitchenTask(kitchener, preparationDate);
            return kitchenTask;
        }
    }
}
