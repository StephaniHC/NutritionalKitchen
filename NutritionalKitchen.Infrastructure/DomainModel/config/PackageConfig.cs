using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.DomainModel.config
{
    public class PackageConfig : IEntityTypeConfiguration<Package>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

            builder.Property(x => x.LabelId)
                .HasColumnName("LabelId");

        } 
    }
}
