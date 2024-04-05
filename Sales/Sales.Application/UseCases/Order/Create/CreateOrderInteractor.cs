using Sales.Domain.Order.Create;

namespace Sales.Application.UseCases.Order.Create;

public class CreateOrderInteractor
{
    public CreateOrder CreateOrder { get; private set; }
    public string OrderNumber { get; set; }

    public CreateOrderInteractor(CreateOrder createOrder)
    {
        CreateOrder = createOrder;
    }
}