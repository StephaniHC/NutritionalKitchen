using MediatR; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.PreparedFood.GetPreparedFood
{ 
    public record GetPreparedFoodQuery(string SearchTerm) : IRequest<IEnumerable<PreparedFoodDTO>>;
}
