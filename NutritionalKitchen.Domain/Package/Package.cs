using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public class Package : AggregateRoot
    {
        public string Status { get; private set; }
        public string BatchCode { get; private set; }
        public Guid PreparedRecipeId { get; private set; }
        public Guid LabelId { get; private set; }
        public Package(string status, string batchCode, Guid preparedRecipeId, Guid labelId) : base(Guid.NewGuid())
        {
            Status = status;
            BatchCode = batchCode;
            PreparedRecipeId = preparedRecipeId;
            LabelId = labelId;
        }

        public void UpdateStatus(string newStatus)
        {
            var validStatuses = new[] { "Pending", "InProgress", "Completed", "Canceled" };
            if (!validStatuses.Contains(newStatus))
                throw new ArgumentException("El estado especificado no es válido.");
            Status = newStatus;
        }
    }
}
