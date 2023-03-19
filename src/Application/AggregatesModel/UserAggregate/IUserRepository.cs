namespace Application.AggregatesModel.UserAggregate;

public interface IUserRepository 
{
    Task<User> GetUserByDocumentAsync(string document, CancellationToken cancellationToken);
    Task AddUserAsync(User user, CancellationToken cancellationToken);
    Task ActiveUserAsync(Guid id, CancellationToken cancellationToken);
    Task InactiveUserAsync(Guid id, CancellationToken cancellationToken);
}