using Sales.Domain.Enums;

namespace Sales.Domain.Order.Create;

public class CreateOrder
{
    public List<int> Products { get; set; }
    public string SellerCode { get; set; }
    public string DelivererCode { get; set; }
    public OrderState OrderState => OrderState.Queued;
    public DateTime OrderDate => DateTime.Now;

    public CreateOrder(List<int> products, string sellerCode, string delivererCode)
    {
        Products = products;
        SellerCode = sellerCode;
        DelivererCode = delivererCode;
    }
}