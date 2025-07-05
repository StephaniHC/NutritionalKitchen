using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.DomainModel.config
{
    public class PreparedFoodConfig : IEntityTypeConfiguration<PreparedFood>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PreparedFood> builder)
        {
            builder.ToTable("PreparedFood");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.IdKitchenTask)
                .HasColumnName("IdKitchenTask");

            builder.Property(x => x.IdRecipePreparation)
                .HasColumnName("IdRecipePreparation");

            builder.Property(x => x.RecipePreparationDate)
                .HasColumnName("RecipePreparationDate");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

            builder.Property(x => x.Recipe)
                .HasColumnName("Recipe");

            builder.Property(x => x.Detail)
                .HasColumnName("Detail");

            builder.Property(x => x.PatientId)
                .HasColumnName("PatientId");

            builder.Property(x => x.LabelId)
                .HasColumnName("LabelId");

        }
    }
}
