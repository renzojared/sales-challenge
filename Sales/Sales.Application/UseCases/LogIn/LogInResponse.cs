namespace Sales.Application.UseCases.LogIn;

public class LogInResponse
{
    public string Token { get; private set; }
    public int ExpirationTimeInSeconds { get; private set; }

    public LogInResponse(string token, int expirationTimeInSeconds)
    {
        Token = token;
        ExpirationTimeInSeconds = expirationTimeInSeconds;
    }
}