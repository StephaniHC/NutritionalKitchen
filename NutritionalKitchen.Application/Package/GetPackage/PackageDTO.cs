using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.GetPackage
{
    public class PackageDTO
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public Guid LabelId { get; set; }
    }
}
