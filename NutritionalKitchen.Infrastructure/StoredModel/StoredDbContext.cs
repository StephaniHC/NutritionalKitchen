using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Infrastructure.StoredModel.Entities;
using NutritionalKitchen.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDatabase = NutritionalKitchen.Infrastructure.Repositories.IDatabase;

namespace NutritionalKitchen.Infrastructure.StoredModel
{
    public class StoredDbContext : DbContext, IDatabase
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
