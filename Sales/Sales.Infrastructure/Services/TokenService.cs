using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sales.Application.Interfaces.Services;
using Sales.Domain.LogIn;
using Sales.Domain.Options;

namespace Sales.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IOptions<JwtOptions> _jwtOptions;
    private readonly IOptions<ClaimOptions> _claimOptions;

    public TokenService(IOptions<JwtOptions> jwtOptions, IOptions<ClaimOptions> claimOptions)
    {
        _jwtOptions = jwtOptions;
        _claimOptions = claimOptions;
    }

    public Task<TokenSuccessful> GenerateJwt(string user)
    {
        var tokenDescriptor = GetTokenDescriptor(user);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var result = new TokenSuccessful(
            tokenHandler.WriteToken(token),
            tokenDescriptor.Expires,
            _jwtOptions.Value.ExpirationTimeInMinutes);

        return Task.FromResult(result);
    }

    private SecurityTokenDescriptor GetTokenDescriptor(string user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Company", _claimOptions.Value.Company),
                new("User", user)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.Value.ExpirationTimeInMinutes),
            SigningCredentials = credentials
        };
    }
}