using Sales.Application.Interfaces.Repositories;
using Sales.Domain.Enums;

namespace Sales.Application.UseCases.Order.NextState.Handlers;

internal class ValidateOrderHandler : Handler<NextStateOrderInteractor>
{
    private readonly IQueriesRepository _queriesRepository;

    public ValidateOrderHandler(IQueriesRepository queriesRepository)
        => _queriesRepository = queriesRepository;

    public override async Task Process(NextStateOrderInteractor interactor)
    {
        interactor.Order = _queriesRepository.Orders
            .FirstOrDefault(s => s.State != OrderState.Received && s.Number == interactor.NextStateOrder.OrderNumber);

        if (interactor.Order is null)
            return;

        await Succesor?.Process(interactor);
    }
}