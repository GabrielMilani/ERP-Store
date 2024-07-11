using ERP_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Store.Infra.EntityConfiguration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ValuePay).HasColumnType("NUMERIC").HasPrecision(10, 2);
        builder.Property(x => x.ValuePaid).HasColumnType("NUMERIC").HasPrecision(10, 2);
        builder.Property(x => x.CreatedDate).HasColumnType("SMALLDATETIME").IsRequired();
        builder.Property(x => x.PaymentDate).HasColumnType("SMALLDATETIME").IsRequired();

    }
}