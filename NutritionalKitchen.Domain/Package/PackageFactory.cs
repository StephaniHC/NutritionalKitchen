using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public class PackageFactory : IPackageFactory
    {
        public Package Create(string status, Guid labelId)
        { 
            Package package = new Package(status, labelId);
            return package;
        }
    }
}
