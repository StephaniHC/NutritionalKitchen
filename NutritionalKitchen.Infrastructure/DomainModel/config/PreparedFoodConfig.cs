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

        }
    }
}
