namespace Application.Share;

public interface IHandler<T> where T : ICommand 
{
    Task Handler(T command, CancellationToken cancellationToken = default);
}