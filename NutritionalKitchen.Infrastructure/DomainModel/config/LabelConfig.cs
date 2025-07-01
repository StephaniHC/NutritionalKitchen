using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.DomainModel.config
{
    public class LabelConfig : IEntityTypeConfiguration<Label>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Label");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.ProductionDate)
                .HasColumnName("ProductionDate");

            builder.Property(x => x.ExpirationDate)
                .HasColumnName("ExpirationDate");

            builder.Property(x => x.DeliberyDate)
                .HasColumnName("DeliberyDate");

            builder.Property(x => x.Detail)
                .HasColumnName("Detail");

            builder.Property(x => x.Address)
                .HasColumnName("Address");

            builder.Property(x => x.ContractId)
                .HasColumnName("ContractId");

            builder.Property(x => x.PatientId)
                .HasColumnName("PatientId");

            builder.Property(x => x.DeliberyId)
                .HasColumnName("DeliberyId");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

        } 
    }
}
