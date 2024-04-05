namespace Sales.Domain.Options;

public class JwtOptions
{
    public const string SectionKey = nameof(JwtOptions);
    public string Key { get; set; }
    public int ExpirationTimeInMinutes { get; set; }
}