using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sales.Domain.Entities;
using Sales.Domain.Options;

namespace Sales.Infrastructure.DataAccess.Contexts;

public class SalesContext : DbContext
{
    private readonly IOptions<DbOptions> dbOptions;

    public SalesContext(IOptions<DbOptions> dbOptions)
        => this.dbOptions = dbOptions;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(dbOptions.Value.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
