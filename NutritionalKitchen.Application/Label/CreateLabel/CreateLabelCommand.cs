using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.CreateLabel
{ 
    public record CreateLabelCommand(Guid id, DateTime productionDate, DateTime expirationDate, DateTime deliberyDate, string detail, string address, Guid contractId, Guid patientId, Guid deliberyId, bool status) : IRequest<Guid>;

}
