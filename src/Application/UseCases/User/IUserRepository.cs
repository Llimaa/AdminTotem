using Application.UserUseCases;

namespace Application.ServiceUseCase;

public interface IUserRepository 
{
    Task<User> GetUserByDocumentAsync(string document);
    Task AddUserAsync(User user);
    Task ActiveUserAsync(Guid id);
    Task InactiveUserAsync(Guid id);
}