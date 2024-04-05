using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sales.Application.Boundaries;
using Sales.Application.UseCases.LogIn;
using Sales.WebApi.UseCases.LogIn;
using Sales.WebApi.UseCases.Order.Create;
using Sales.WebApi.UseCases.Order.NexState;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddScoped<IOutputPort<string>, NextStateOrderPresenter>();
        services.AddScoped<IOutputPort<string>, CreateOrderPresenter>();
        services.AddScoped<IOutputPort<LogInResponse>, LogInPresenter>();
        
        return services;
    }

    /// <summary>
    /// Docs: https://learn.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-7.0
    /// </summary>
    /// <param name="services"></param>
    /// <param name="jwtKey"></param>
    /// <returns></returns>
    public static IServiceCollection AddJwtServices(this IServiceCollection services, string jwtKey)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                s =>
                {
                    s.RequireHttpsMetadata = false;
                    s.SaveToken = true;
                    s.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

        services
            .AddAuthorization(s =>
            {
                s.AddPolicy(
                    JwtBearerDefaults.AuthenticationScheme,
                    s =>
                    {
                        s.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                        s.RequireAuthenticatedUser();
                        s.Build();
                    });
            });

        return services;
    }

    /// <summary>
    /// Video reference: https://www.youtube.com/watch?v=EHLlH_9oS5Q
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Write 'Bearer ' + valid JWT token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new string[] { }
                }
            });
        });
        return services;
    }
}