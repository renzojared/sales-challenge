using Sales.Application.Interfaces.Repositories;

namespace Sales.Application.UseCases.Order.Create.Handlers;

internal class CreateOrderHandler : Handler<CreateOrderInteractor>
{
    private readonly ICommandsRepository _commandsRepository;
    private readonly IQueriesRepository _queriesRepository;

    public CreateOrderHandler(ICommandsRepository commandsRepository, IQueriesRepository queriesRepository)
    {
        _commandsRepository = commandsRepository;
        _queriesRepository = queriesRepository;
    }

    public override async Task Process(CreateOrderInteractor interactor)
    {
        var sellerId = _queriesRepository.Employees
            .Where(s => s.Code == interactor.CreateOrder.SellerCode)
            .Select(s => s.Id)
            .FirstOrDefault();
        
        var delivererId = _queriesRepository.Employees
            .Where(s => s.Code == interactor.CreateOrder.DelivererCode)
            .Select(s => s.Id)
            .FirstOrDefault();
        
        var order =  await _commandsRepository.CreateOrder(interactor.CreateOrder, sellerId, delivererId);

        await _commandsRepository.SaveChangesAsync();
        interactor.OrderNumber = order.Number;
    }
}