using Microsoft.AspNetCore.Mvc;

namespace Sales.WebApi.Ports;

public abstract class Presenter
{
    public IActionResult ViewModel { get; protected set; }

    public virtual Task ErrorServer(Exception e)
    {
        var problems = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "Error Server",
            Title = "Ocurrió un error",
            Detail = e.InnerException?.Message ?? e.Message,
            Instance = $"{nameof(ProblemDetails)}/{e.GetType().Name}"
        };
        ViewModel = new ObjectResult(problems)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        return Task.CompletedTask;
    }
}