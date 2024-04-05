using Sales.Application.Interfaces.Repositories;

namespace Sales.Application.UseCases.Order.NextState.Handlers;

internal class ChangeStateHandler : Handler<NextStateOrderInteractor>
{
    private readonly ICommandsRepository _commandsRepository;

    public ChangeStateHandler(ICommandsRepository commandsRepository)
        => _commandsRepository = commandsRepository;

    public override async Task Process(NextStateOrderInteractor interactor)
    {
        _commandsRepository.NextStateOrder(interactor.Order, interactor.NextStateOrder.CurrentDate);
        await _commandsRepository.SaveChangesAsync();
    }
}