using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Boundaries;
using Sales.Application.UseCases.Order.Create;
using Sales.Domain.Order.Create;
using Sales.WebApi.Ports;

namespace Sales.WebApi.UseCases.Order.Create;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IInputPort<CreateOrderInteractor> _inputPort;
    private readonly IOutputPort<string> _presenter;

    public OrderController(IInputPort<CreateOrderInteractor> inputPort, IOutputPort<string> presenter)
    {
        _inputPort = inputPort;
        _presenter = presenter;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        await _inputPort.Execute(new CreateOrderInteractor(
            new CreateOrder(
                request.Products,
                request.SellerCode,
                request.DelivererCode)));
        return ((Presenter)_presenter).ViewModel;
    }
}