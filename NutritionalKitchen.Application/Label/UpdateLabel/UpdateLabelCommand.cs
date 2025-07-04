﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.UpdateLabel
{ 
    public record UpdateLabelCommand(
        Guid DeliberyId, 
        Guid ContractId,  
        string Address,
        bool status
    ) : IRequest<Unit>;
} 