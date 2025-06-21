using MediatR;
using NutritionalKitchen.Application.Label.GetLabel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.GetPackage
{ 
    public record GetPackageQuery(string SearchTerm) : IRequest<IEnumerable<PackageDTO>>;
}
