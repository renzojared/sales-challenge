using Sales.Application.Boundaries;
using Sales.Application.UseCases.Order.Create.Handlers;
using Sales.Application.UseCases.Resources;

namespace Sales.Application.UseCases.Order.Create;

internal class CreateOrderUseCase : IInputPort<CreateOrderInteractor>
{
    private readonly CreateOrderHandler _createOrderHandler;
    private readonly IOutputPort<string> _outputPort;

    public CreateOrderUseCase(CreateOrderHandler createOrderHandler, IOutputPort<string> outputPort)
    {
        _createOrderHandler = createOrderHandler;
        _outputPort = outputPort;
    }

    public async Task Execute(CreateOrderInteractor interactor)
    {
        try
        {
            //TODO:Validations
            await _createOrderHandler.Process(interactor);
            await _outputPort.Standard(string.Format(OrderMessages.CreateOrderDetail, interactor.OrderNumber));
        }
        catch (Exception e)
        {
            await _outputPort.ErrorServer(e);
        }
    }
}