namespace Sales.Domain.Order.NextState;

public class NextStateOrder
{
    public string OrderNumber { get; private set; }
    public DateTime CurrentDate => DateTime.Now;

    public NextStateOrder(string orderNumber)
        => OrderNumber = orderNumber;
}