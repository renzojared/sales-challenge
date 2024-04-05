using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sales.Application.Interfaces.Repositories;
using Sales.Domain.Entities;
using Sales.Domain.Options;
using Sales.Infrastructure.DataAccess.Contexts;

namespace Sales.Infrastructure.DataAccess.Repositories;

internal class QueriesRepository : SalesContext, IQueriesRepository
{
    public QueriesRepository(IOptions<DbOptions> dbOptions) : base(dbOptions)
        => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    public new IQueryable<Employee> Employees => base.Employees;
    public new IQueryable<Order> Orders => base.Orders;
    public new IQueryable<OrderDetail> OrderDetails => base.OrderDetails;
    public new IQueryable<Product> Products => base.Products;

}