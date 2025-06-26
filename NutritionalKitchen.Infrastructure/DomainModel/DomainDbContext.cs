using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Domain.RecipePreparation;
using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.EFCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NutritionalKitchen.Infrastructure.DomainModel
{
    public class DomainDbContext (DbContextOptions<DomainDbContext> options) : DbContext(options)
    {
        public virtual DbSet<KitchenTask> KitchenTask { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PreparedFood> PreparedFood { get; set; }
        public virtual DbSet<RecipePreparation> RecipePreparation { get; set; }
        public DbSet<OutboxMessage<DomainEvent>> OutboxMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddOutboxModel<DomainEvent>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
