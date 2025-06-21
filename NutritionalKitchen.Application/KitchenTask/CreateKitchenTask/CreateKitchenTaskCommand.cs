using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenTask.CreateKitchenTask
{ 
    public record CreateKitchenTaskCommand(string description, string status, string kitchener, DateTime preparationDate) : IRequest<Guid>;

} 