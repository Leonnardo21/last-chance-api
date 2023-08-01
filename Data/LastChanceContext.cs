using LastChance.Data.Mapping;
using LastChance.Models;
using Microsoft.EntityFrameworkCore;

namespace LastChance.Data
{
    public class LastChanceContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=DbLastChance.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());
        }
    }
}
