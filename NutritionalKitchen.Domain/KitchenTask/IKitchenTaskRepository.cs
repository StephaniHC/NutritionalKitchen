using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenTask
{
    public interface IKitchenTaskRepository : IRepository<KitchenTask>
    { 
        Task UpdateAsync(KitchenTask kitchenTask);
        Task DeleteAsync(Guid id);
    }
}
