using Sales.Application.Boundaries;
using Sales.Application.UseCases;
using Sales.Application.UseCases.LogIn;
using Sales.Application.UseCases.Order.Create;
using Sales.Application.UseCases.Order.NextState;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddHandlerServices();
        services.AddScoped<IInputPort<CreateOrderInteractor>, CreateOrderUseCase>();
        services.AddScoped<IInputPort<LogInInteractor>, LogInUseCase>();
        services.AddScoped<IInputPort<NextStateOrderInteractor>, NextStateOrderUseCase>();
        return services;
    }

    private static IServiceCollection AddHandlerServices(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var handlers = assemblies
            .SelectMany(s => s.GetTypes())
            .Where(s => s is { IsAbstract: false, BaseType.IsGenericType: true } &&
                        s.BaseType.GetGenericTypeDefinition() == typeof(Handler<>)).ToList();
        handlers.ForEach(handler => services.AddScoped(handler));

        return services;
    }
}