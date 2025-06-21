using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenTask.GetKitchenTask
{
    public class KitchenTaskDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Kitchener { get; set; }
        public DateTime PreparationDate { get; set; }
    }
}
