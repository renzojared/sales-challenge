namespace Sales.WebApi.UseCases.Order.Create;

public class CreateOrderRequest
{
    public List<int> Products { get; set; }
    public string SellerCode { get; set; }
    public string DelivererCode { get; set; }
}