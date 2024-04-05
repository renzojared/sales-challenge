using Microsoft.AspNetCore.Mvc;
using Sales.Application.Boundaries;
using Sales.Application.UseCases.LogIn;
using Sales.WebApi.Ports;

namespace Sales.WebApi.UseCases.LogIn;

public class LogInPresenter : Presenter, IOutputPort<LogInResponse>
{
    public Task Standard(LogInResponse output)
    {
        ViewModel = new OkObjectResult(new LogInResult(output.Token, output.ExpirationTimeInSeconds));
        return Task.CompletedTask;
    }
}