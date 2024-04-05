namespace Sales.WebApi.UseCases.LogIn;

public class LogInResult
{
    public string BearerToken { get; private set; }
    public int ExpiresIn { get; private set; }

    public LogInResult(string bearerToken, int expiresIn)
    {
        BearerToken = bearerToken;
        ExpiresIn = expiresIn;
    }
}