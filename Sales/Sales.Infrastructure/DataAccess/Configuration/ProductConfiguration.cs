using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using Sales.Domain.Enums;

namespace Sales.Infrastructure.DataAccess.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(s => s.SKU)
            .HasMaxLength(36)
            .IsRequired();

        builder
            .Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(s => s.Type)
            /*.HasConversion(
                s => s.ToString(),
                s => (ProductType)Enum.Parse(typeof(ProductType), s))*/
            .IsRequired();

        builder
            .Property(s => s.Tags)
            .HasMaxLength(200);

        builder
            .Property(s => s.UnitPrice)
            .HasPrecision(8,2)
            .IsRequired();

        builder
            .Property(s => s.MeasureType)
            .IsRequired();

        builder.HasKey(s => s.Id);

        builder
            .HasData(
                new()
                {
                    Id = 1, SKU = Guid.NewGuid().ToString(), Name = "Potato", Type = ProductType.Foods,
                    UnitPrice = 10.2m, MeasureType = MeasureType.Kilogram
                },
                new()
                {
                    Id = 2, SKU = Guid.NewGuid().ToString(), Name = "Apple", Type = ProductType.Foods,
                    UnitPrice = 5.4m, MeasureType = MeasureType.Kilogram
                },
                new()
                {
                    Id = 3, SKU = Guid.NewGuid().ToString(), Name = "Chicken", Type = ProductType.Foods,
                    UnitPrice = 15.7m, MeasureType = MeasureType.Kilogram
                },
                new()
                {
                    Id = 4, SKU = Guid.NewGuid().ToString(), Name = "Fish", Type = ProductType.Foods,
                    UnitPrice = 13.4m, MeasureType = MeasureType.Kilogram
                },
                new()
                {
                    Id = 5, SKU = Guid.NewGuid().ToString(), Name = "Orange Juice", Type = ProductType.Foods,
                    UnitPrice = 10.2m, MeasureType = MeasureType.Liter
                }
            );
    }
}