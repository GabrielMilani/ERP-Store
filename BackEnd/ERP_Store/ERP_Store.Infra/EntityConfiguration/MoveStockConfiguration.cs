using ERP_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Store.Infra.EntityConfiguration;

public class MoveStockConfiguration : IEntityTypeConfiguration<MoveStock>
{
    public void Configure(EntityTypeBuilder<MoveStock> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.QuantityMoved).HasColumnType("NUMERIC").HasPrecision(10, 2);
        builder.Property(x => x.DateMoved).HasColumnType("SMALLDATETIME").IsRequired();
    }
}