using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.Label;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.PreparedFood;
using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.DomainModel
{
    public class DomainDbContext (DbContextOptions<DomainDbContext> options) : DbContext(options)
    {
        public virtual DbSet<KitchenTask> KitchenTask { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PreparedFood> PreparedFood { get; set; }
        public virtual DbSet<RecipePreparation> RecipePreparation { get; set; }  
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly); 
            base.OnModelCreating(modelBuilder); 
        }
    }
}
