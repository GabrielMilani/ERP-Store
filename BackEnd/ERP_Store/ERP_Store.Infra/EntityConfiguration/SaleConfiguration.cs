using ERP_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Store.Infra.EntityConfiguration;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SoldQuantity).HasColumnType("NUMERIC").HasPrecision(10, 2);
        builder.Property(x => x.CreatedDate).HasColumnType("SMALLDATETIME").IsRequired();
        builder.Property(x => x.ClosingDate).HasColumnType("SMALLDATETIME").IsRequired();
    }
}