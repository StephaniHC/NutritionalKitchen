using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Label
{
    public class LabelFactory : ILabelFactory
    {
        public Label Create(Guid id, DateTime productionDate, DateTime expirationDate, DateTime deliberyDate, string detail, string address, Guid contractId, Guid patientId, Guid deliberyId, bool status)
        { 
            Label label = new Label(id, productionDate, expirationDate, deliberyDate, detail, address, contractId, patientId, deliberyId, status);
            return label;
        }
    }
}
