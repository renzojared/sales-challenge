using Sales.Application.Boundaries;
using Sales.Application.UseCases.Order.NextState.Handlers;
using Sales.Application.UseCases.Resources;
using Sales.Domain.Extensions;

namespace Sales.Application.UseCases.Order.NextState;

internal class NextStateOrderUseCase : IInputPort<NextStateOrderInteractor>
{
    private readonly IOutputPort<string> _outputPort;
    private readonly ValidateOrderHandler _validateOrderHandler;

    public NextStateOrderUseCase(ValidateOrderHandler validateOrderHandler,
        ChangeStateHandler changeStateHandler,
        IOutputPort<string> outputPort)
    {
        validateOrderHandler
            .SetSuccesor(changeStateHandler);

        _validateOrderHandler = validateOrderHandler;
        _outputPort = outputPort;
    }

    public async Task Execute(NextStateOrderInteractor input)
    {
        try
        {
            //TODO:Validations
            await _validateOrderHandler.Process(input);
            await _outputPort.Standard(string.Format(OrderMessages.NextStateOrderDetail, input.Order.Id,
                input.Order.State.ToString()));
        }
        catch (Exception e)
        {
            await _outputPort.ErrorServer(e);
        }
    }
}