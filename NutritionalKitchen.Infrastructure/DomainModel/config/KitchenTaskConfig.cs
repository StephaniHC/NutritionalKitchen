using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.KitchenTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.DomainModel.config
{
    public class KitchenTaskConfig : IEntityTypeConfiguration<KitchenTask>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<KitchenTask> builder)
        {
            builder.ToTable("KitchenTask");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Description)
                .HasColumnName("Description");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

            builder.Property(x => x.Kitchener)
                .HasColumnName("Kitchener");

            builder.Property(x => x.PreparationDate)
                .HasColumnName("PreparationDate");

        } 
    }
}
