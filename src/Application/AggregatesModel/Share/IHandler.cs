namespace Application.Share;

public interface IHandler<T> where T : ICommand 
{
    Task HandlerAsync(T command, CancellationToken cancellationToken = default);
}