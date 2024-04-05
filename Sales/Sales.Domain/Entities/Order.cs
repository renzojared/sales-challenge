using Sales.Domain.Enums;

namespace Sales.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ReceptionDate { get; set; }
    public DateTime? ShipmentDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public OrderState State { get; set; }
    public HashSet<OrderDetail> OrderDetails { get; set; } = new();
    public int SellerId { get; set; }
    public Employee Seller { get; set; }
    public int DelivererId { get; set; }
    public Employee Deliverer { get; set; }
}