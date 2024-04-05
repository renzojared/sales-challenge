using Sales.Domain.Enums;

namespace Sales.Domain.Extensions;

public static class OrderStateExtensions
{
    public static OrderState GetNextState(this OrderState currentState)
    {
        return currentState switch
        {
            OrderState.Queued => OrderState.Processing,
            OrderState.Processing => OrderState.Delivering,
            OrderState.Delivering => OrderState.Received,
            _ => throw new ArgumentOutOfRangeException(nameof(currentState), "Siguiente estado inválido")
        };
    }
}