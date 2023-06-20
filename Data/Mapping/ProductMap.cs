using LastChanceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LastChanceAPI.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Lot)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder.Property(x => x.Expiration)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType("INT");
        }
    }
}