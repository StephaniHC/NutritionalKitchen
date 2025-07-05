using MediatR;
using NutritionalKitchen.Application.KitchenTask.GetKitchenTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.GetLabel
{ 
    public record GetLabelQuery(string SearchTerm) : IRequest<IEnumerable<LabelDTO>>;
    public record GetLabelByTodayQuery(Guid PatientId) : IRequest<IEnumerable<LabelDTO>>;
}
