using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.PreparedFood.GetPreparedFood
{
    public class PreparedFoodDTO
    { 
        public Guid Id { get; set; } 
        public Guid IdKitchenTask { get; set; }
    }
}
