using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Label
{
    public interface ILabelRepository : IRepository<Label>
    {
        Task UpdateAsync(Label label);
        Task DeleteAsync(Guid id);
    }
}
