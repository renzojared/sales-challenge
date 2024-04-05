using Sales.Application.Interfaces;
using Sales.Application.Interfaces.Repositories;
using Sales.Application.Interfaces.Services;
using Sales.Domain.Options;
using Sales.Infrastructure.DataAccess.Repositories;
using Sales.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Action<DbOptions> dbOptions,
        Action<JwtOptions> jwtOptions, Action<ClaimOptions> claimOptions)
    {
        services.Configure(dbOptions);
        services.Configure(jwtOptions);
        services.Configure(claimOptions);
        services.AddScoped<ICommandsRepository, CommandsRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}