using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenTask
{
    public interface IKitchenTaskFactory
    {
        KitchenTask Create(string description, string status, string kitchener, DateTime preparationDate);
    }
}
