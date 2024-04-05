using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.DataAccess.Configuration;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .Property(s => s.Number)
            .HasComputedColumnSql("CONCAT('1000', CAST(Id AS VARCHAR))")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(s => s.OrderDate)
            .IsRequired();

        builder
            .Property(s => s.State)
            .IsRequired();
        
        builder
            .HasMany(s => s.OrderDetails)
            .WithOne(s => s.Order)
            .HasForeignKey(s => s.OrderId);

        builder
            .HasOne(s => s.Seller)
            .WithMany()
            .HasForeignKey(s => s.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(s => s.Deliverer)
            .WithMany()
            .HasForeignKey(s => s.DelivererId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasKey(s => s.Id);
    }
}