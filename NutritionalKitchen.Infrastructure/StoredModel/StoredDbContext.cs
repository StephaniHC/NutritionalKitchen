using Microsoft.EntityFrameworkCore;
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
    }
}
