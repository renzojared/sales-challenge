using Sales.Domain.Enums;
using Sales.Domain.Order.NextState;

namespace Sales.Application.UseCases.Order.NextState;

public class NextStateOrderInteractor
{
    public NextStateOrder NextStateOrder { get; private set; }
    public Domain.Entities.Order? Order { get; set; }

    public NextStateOrderInteractor(NextStateOrder nextStateOrder)
    {
        NextStateOrder = nextStateOrder;
    }
}