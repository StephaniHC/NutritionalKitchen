using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.RecipePreparation
{
    public class Recipe : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; } 
        public Recipe(Guid id, string name, string description) : base(Guid.NewGuid())
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
