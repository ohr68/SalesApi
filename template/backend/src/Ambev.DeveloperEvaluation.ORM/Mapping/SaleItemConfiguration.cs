using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SalesItems");

        builder.HasKey(si => si.Id);
        builder.Property(si => si.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(si => si.Quantity)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(si => si.Discounts)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(si => si.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(si => si.Cancelled)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne<Product>(si => si.Product)
            .WithMany(p => p.SalesItems)
            .HasForeignKey(si => si.ProductId);
    }
}