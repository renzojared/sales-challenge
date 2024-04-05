using Sales.Domain.LogIn;

namespace Sales.Application.Interfaces.Services;

public interface ITokenService
{
    Task<TokenSuccessful> GenerateJwt(string user);
}