using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;


public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Number)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(s => s.MadeOn)
            .HasColumnType("datetime2(7)")
            .IsRequired();

        builder.Property(s => s.Customer)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(s => s.TotalAmount)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.Property(s => s.Branch)
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(s => s.Cancelled)
            .HasColumnType("boolean")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany<SaleItem>(s => s.Items)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId);
    }
}