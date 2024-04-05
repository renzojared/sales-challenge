using Sales.Domain.Entities;

namespace Sales.Application.Interfaces.Repositories;

public interface IQueriesRepository
{
    IQueryable<Employee> Employees { get; }
    IQueryable<Order> Orders { get; }
    IQueryable<OrderDetail> OrderDetails { get; }
    IQueryable<Product> Products { get; }
    //Listado de productos por SKU o nombre
    //Listado de pedidos por Nro de Pedido
    //Detalle de pedido - desglose de pedido
}