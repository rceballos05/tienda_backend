using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tienda.Domain.Entities;

namespace Tienda.Infrastructure.Persistences.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasIndex(e => e.Category, "product_category");

            builder.HasIndex(e => e.Discount, "product_discount");

            builder.HasIndex(e => e.Name, "product_name");

            builder.HasIndex(e => e.Price, "product_price");

            builder.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            builder.Property(e => e.Category)
                .HasColumnType("int(11)")
                .HasColumnName("category");

            builder.Property(e => e.Discount)
                .HasColumnType("int(11)")
                .HasColumnName("discount");

            builder.Property(e => e.Name).HasColumnName("name");

            builder.Property(e => e.Price).HasColumnName("price");

            builder.Property(e => e.UrlImage)
                .HasMaxLength(255)
                .HasColumnName("url_image");

            builder.HasOne(d => d.CategoryNavigation)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("product_ibfk_1");
        }
    }
}
