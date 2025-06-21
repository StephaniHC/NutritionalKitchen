using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Label
{
    public interface ILabelFactory
    {
        Label Create(DateTime productionDate, DateTime expirationDate, DateTime deliberyDate, string detail, string address, Guid contractId, Guid patientId);
    }
}
