using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Boundaries;
using Sales.Application.UseCases.Order.NextState;
using Sales.Domain.Order.NextState;
using Sales.WebApi.Ports;

namespace Sales.WebApi.UseCases.Order.NexState;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IInputPort<NextStateOrderInteractor> _inputPort;
    private readonly IOutputPort<string> _outputPort;

    public OrderController(IInputPort<NextStateOrderInteractor> inputPort, IOutputPort<string> outputPort)
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> NextState([FromBody] NextStateOrderRequest request)
    {
        await _inputPort.Execute(new NextStateOrderInteractor(
            new NextStateOrder(request.OrderNumber)));

        return ((Presenter)_outputPort).ViewModel;
    }
}