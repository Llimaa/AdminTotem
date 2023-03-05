namespace Application.AggregatesModel.UserAggregate;

public interface IUserRepository 
{
    Task<UserModel> GetUserByDocumentAsync(string document, CancellationToken cancellationToken);
    Task AddUserAsync(UserModel user, CancellationToken cancellationToken);
    Task ActiveUserAsync(Guid id, CancellationToken cancellationToken);
    Task InactiveUserAsync(Guid id, CancellationToken cancellationToken);
}