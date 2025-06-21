using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Label
{
    public class LabelFactory : ILabelFactory
    {
        public Label Create(DateTime productionDate, DateTime expirationDate, DateTime deliberyDate, string detail, string address, Guid contractId, Guid patientId)
        { 
            Label label = new Label(productionDate, expirationDate, deliberyDate, detail, address, contractId, patientId);
            return label;
        }
    }
}
