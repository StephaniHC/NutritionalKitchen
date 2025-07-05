using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.PreparedFood
{
    public interface IPreparedFoodRepository : IRepository<PreparedFood>
    {
        Task UpdateAsync(PreparedFood preparedFood);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<PreparedFood>> GetByPreparationDateAsync(DateTime preparationDate);
    }
}
