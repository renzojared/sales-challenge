namespace Sales.Domain.Options;

public class DbOptions
{
    public const string SectionKey = nameof(DbOptions);
    public string ConnectionString { get; set; }
}