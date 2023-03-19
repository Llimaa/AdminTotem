
using Application.Share;

namespace Application.AggregatesModel.UserAggregate;

public class UserHandler : IHandler<AddUserCommand>, IHandler<ActiveUserCommand>, IHandler<InactiveUserCommand>
{
    private readonly IUserRepository userRepository;

    public UserHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task HandlerAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(command.Name, command.Email, command.Document);
        await userRepository.AddUserAsync(user, cancellationToken);
    }

    public async Task HandlerAsync(ActiveUserCommand command, CancellationToken cancellationToken)
    {
        var id = command.Id;
        await userRepository.ActiveUserAsync(id, cancellationToken);
    }

    public async Task HandlerAsync(InactiveUserCommand command, CancellationToken cancellationToken)
    {
        var id = command.Id;
        await userRepository.InactiveUserAsync(id, cancellationToken);
    }
}