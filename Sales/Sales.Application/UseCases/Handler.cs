namespace Sales.Application.UseCases;

public abstract class Handler<T>
{
    protected Handler<T>? Succesor;

    public Handler<T> SetSuccesor(Handler<T> succesor)
        => Succesor = succesor;

    public abstract Task Process(T interactor);
}