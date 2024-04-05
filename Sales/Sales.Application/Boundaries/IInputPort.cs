namespace Sales.Application.Boundaries;

public interface IInputPort<T>
{
    Task Execute(T input);
}