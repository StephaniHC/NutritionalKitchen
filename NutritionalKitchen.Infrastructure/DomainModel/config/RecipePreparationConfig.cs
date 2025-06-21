using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.DomainModel.config
{
    public class RecipePreparationConfig : IEntityTypeConfiguration<RecipePreparation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RecipePreparation> builder)
        {
            builder.ToTable("recipePreparation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.RecipeName)
                .HasColumnName("RecipeName");

            builder.Property(x => x.Detail)
                .HasColumnName("Detail");

            builder.Property(x => x.PreparationDate)
                .HasColumnName("PreparationDate"); 

            builder.Property(x => x.PatientId)
                .HasColumnName("PatientId"); 
        }
    }
}
