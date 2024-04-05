namespace Sales.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}