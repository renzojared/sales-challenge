using Microsoft.EntityFrameworkCore.Design;
using Sales.Domain.Options;

namespace Sales.Infrastructure.DataAccess.Contexts;

public class SalesContextFactory : IDesignTimeDbContextFactory<SalesContext>
{
    public SalesContext CreateDbContext(string[] args)
    {
        var dbOptions = Microsoft.Extensions.Options.Options.Create(
            new DbOptions
            {
                ConnectionString = "Server=localhost;Database=SalesDB;User Id=sa;Password=D@cker09;TrustServerCertificate=True;Encrypt=False;"
            });
        return new SalesContext(dbOptions);
    }
}