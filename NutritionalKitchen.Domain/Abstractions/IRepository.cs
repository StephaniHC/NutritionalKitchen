using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Abstractions
{
    public interface IRepository <TEntity> where TEntity : Entity
    {
        Task<TEntity?> GetByIdAsync(Guid id, bool readOnly = false);
        Task AddAsync(TEntity entity);
    }
}
