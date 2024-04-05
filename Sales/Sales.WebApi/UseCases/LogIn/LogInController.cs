using Microsoft.AspNetCore.Mvc;
using Sales.Application.Boundaries;
using Sales.Application.UseCases.LogIn;
using Sales.WebApi.Ports;

namespace Sales.WebApi.UseCases.LogIn;

[Route("api/[controller]/[action]")]
[ApiController]
public class LogInController : ControllerBase
{
    private readonly IInputPort<LogInInteractor> _inputPort;
    private readonly IOutputPort<LogInResponse> _outputPort;

    public LogInController(IInputPort<LogInInteractor> inputPort, IOutputPort<LogInResponse> outputPort)
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpPost]
    [ProducesResponseType(typeof(LogInResult), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> Token([FromBody] LogInRequest request)
    {
        await _inputPort.Execute(new LogInInteractor(
            request.Username,
            request.Password));

        return ((Presenter)_outputPort).ViewModel;
    }
}