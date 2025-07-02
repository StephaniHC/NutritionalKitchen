using Joseco.Communication.External.Contracts.Message; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NutritionalKitchen.Integration.RecipePreparation
{
    public record RecipePreparation : IntegrationMessage
    {
        public Guid RecipeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public RecipePreparation(
            Guid recipeId,
            Guid id, 
            string? name = null,
            string? description = null,
            DateTime? createdAt = null, 
            string? correlationId = null,
            string? source = null
        ) : base(correlationId, source)
        {
            RecipeId = recipeId;
            Name = name;
            Description = description;
            Id = id;
            CreatedAt = createdAt ?? DateTime.UtcNow;   
        }
    }
}
