using Sales.Domain.Enums;

namespace Sales.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public ProductType Type { get; set; }
    public string? Tags { get; set; }
    public decimal UnitPrice { get; set; }
    public MeasureType MeasureType { get; set; }
}