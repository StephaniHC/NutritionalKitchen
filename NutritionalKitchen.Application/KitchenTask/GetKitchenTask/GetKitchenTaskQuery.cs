﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenTask.GetKitchenTask
{
    public record GetKitchenTaskQuery(string SearchTerm) : IRequest<IEnumerable<KitchenTaskDTO>>;
}
