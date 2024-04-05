using Microsoft.AspNetCore.Mvc;
using Sales.Application.Boundaries;
using Sales.WebApi.Ports;

namespace Sales.WebApi.UseCases.Order.NexState;

internal class NextStateOrderPresenter : Presenter, IOutputPort<string>
{
    public Task Standard(string output)
    {
        ViewModel = new OkObjectResult(output);
        return Task.CompletedTask;
    }
}