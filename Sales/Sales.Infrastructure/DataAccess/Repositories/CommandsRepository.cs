using Microsoft.Extensions.Options;
using Sales.Application.Interfaces.Repositories;
using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Sales.Domain.Extensions;
using Sales.Domain.Options;
using Sales.Domain.Order.Create;
using Sales.Infrastructure.DataAccess.Contexts;

namespace Sales.Infrastructure.DataAccess.Repositories;

internal class CommandsRepository : SalesContext, ICommandsRepository
{
    public CommandsRepository(IOptions<DbOptions> dbOptions) : base(dbOptions)
    {
    }

    public async Task SaveChangesAsync()
        => await base.SaveChangesAsync();

    public async Task<Order> CreateOrder(CreateOrder order, int sellerId, int delivererId)
    {
        var orderDb = new Order
        {
            OrderDate = order.OrderDate,
            State = order.OrderState,
            SellerId = sellerId,
            DelivererId = delivererId
        };
        await AddAsync(orderDb);
        await AddRangeAsync(order.Products.Select(s => new OrderDetail
        {
            Order = orderDb,
            ProductId = s
        }));
        return orderDb;
    }

    /// <summary>
    /// EF Core Update: https://www.learnentityframeworkcore.com/dbcontext/modifying-data
    /// </summary>
    /// <param name="order"></param>
    /// <param name="updateDate"></param>
    public void NextStateOrder(Order order, DateTime updateDate)
    {
        Attach(order);
        order.State = order.State.GetNextState();
        Entry(order).Property(s => s.State).IsModified = true;

        switch (order.State)
        {
            case OrderState.Processing:
                order.ReceptionDate = updateDate;
                Entry(order).Property(s => s.ReceptionDate).IsModified = true;
                break;
            case OrderState.Delivering:
                order.ShipmentDate = updateDate;
                Entry(order).Property(s => s.ShipmentDate).IsModified = true;
                break;
            case OrderState.Received:
                order.DeliveryDate = updateDate;
                Entry(order).Property(s => s.DeliveryDate).IsModified = true;
                break;
        }
    }
}