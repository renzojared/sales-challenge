using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.DataAccess.Configuration;

internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder
            .HasKey(s => new { s.OrderId, s.ProductId });

        builder
            .HasOne(s => s.Order)
            .WithMany(s => s.OrderDetails)
            .HasForeignKey(s => s.OrderId);

        builder
            .HasOne(s => s.Product)
            .WithMany()
            .HasForeignKey(s => s.ProductId);
    }
}