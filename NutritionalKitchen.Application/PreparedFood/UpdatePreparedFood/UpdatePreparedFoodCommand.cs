﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.PreparedFood.UpdatePreparedFood
{
    public record UpdatePreparedFoodCommand(DateTime RecipePreparationDate) : IRequest<Unit>;

}
