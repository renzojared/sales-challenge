using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Sales.Domain.Order.Create;

namespace Sales.Application.Interfaces.Repositories;

public interface ICommandsRepository : IUnitOfWork
{
    Task<Order> CreateOrder(CreateOrder order, int sellerId, int delivererId);
    void NextStateOrder(Order order, DateTime updateDate);
}