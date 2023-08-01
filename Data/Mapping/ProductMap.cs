using LastChance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LastChance.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Tb_Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Lot)
                .IsRequired();

            builder.Property(x => x.CodeBar)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(x => x.Expiration)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(x => x.Quantity);
            
        }
    }
}
