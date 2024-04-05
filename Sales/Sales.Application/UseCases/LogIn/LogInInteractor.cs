namespace Sales.Application.UseCases.LogIn;

public class LogInInteractor
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    public LogInInteractor(string username, string password)
    {
        Username = username;
        Password = password;
    }
}