﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.CreatePackage
{ 
    public record CreatePackageCommand(string status, Guid labelId) : IRequest<Guid>;
     
}
