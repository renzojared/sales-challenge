using Sales.Application.Boundaries;
using Sales.Application.Interfaces.Repositories;
using Sales.Application.Interfaces.Services;

namespace Sales.Application.UseCases.LogIn;

internal class LogInUseCase : IInputPort<LogInInteractor>
{
    private readonly IOutputPort<LogInResponse> _outputPort;
    private readonly IQueriesRepository _queriesRepository;
    private readonly ITokenService _tokenService;

    public LogInUseCase(IOutputPort<LogInResponse> outputPort, IQueriesRepository queriesRepository, ITokenService tokenService)
    {
        _outputPort = outputPort;
        _queriesRepository = queriesRepository;
        _tokenService = tokenService;
    }

    public async Task Execute(LogInInteractor input)
    {
        try
        {
            var validate = _queriesRepository.Employees
                .Any(s => s.Email == input.Username && s.Password == input.Password);

            if(!validate)
                return;

            var result = await _tokenService.GenerateJwt(input.Username);
            await _outputPort.Standard(new LogInResponse(result.Token, result.ExpirationTimeInSeconds));

        }
        catch (Exception e)
        {
            await _outputPort.ErrorServer(e);
        }
    }
}