using Microsoft.EntityFrameworkCore;
using Joseco.Outbox.EFCore.Persistence;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.StoredModel
{
    public class StoredDbContext : DbContext
    {
        public virtual DbSet<KitchenTaskStoredModel> KitchenTask { get; set; }
        public virtual DbSet<LabelStoredModel> Label { get; set; }
        public virtual DbSet<PackageStoredModel> Package { get; set; }
        public virtual DbSet<PreparedFoodStoredModel> PreparedFood { get; set; }
        public virtual DbSet<RecipePreparationStoredModel> RecipePreparation { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {

        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddOutboxModel<DomainEvent>();
        }

        public void Migrate()
        {
            Database.Migrate();
        }
    }
}
