using LastChanceAPI.Data.Mapping;
using LastChanceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LastChanceAPI.Data
{
    public class LastChanceContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=<Server>;Database=<Db>;User ID=sa;Password=<Pass>;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
        }
    }

}
