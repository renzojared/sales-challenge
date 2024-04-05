namespace Sales.Application.Boundaries;

public interface IOutputPort<T>
{
    //TODO:Error Bad Request
    Task ErrorServer(Exception e);
    Task Standard(T output);
}