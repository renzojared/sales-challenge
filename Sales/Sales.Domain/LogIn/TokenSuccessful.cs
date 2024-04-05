namespace Sales.Domain.LogIn;

public class TokenSuccessful
{
    public string? Token { get; set; }
    public DateTime? Expires { get; set; }
    public int ExpirationTimeInSeconds { get; set; }

    public TokenSuccessful(string? token, DateTime? expires, int expirationTimeInMinutes)
    {
        Token = token;
        Expires = expires;
        ExpirationTimeInSeconds = expirationTimeInMinutes * 60;
    }
}