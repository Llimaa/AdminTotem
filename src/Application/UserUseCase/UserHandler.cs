using Application.ServiceUseCase;
using Application.Share;

namespace Application.UserUseCases;

public class UserHandler : IHandler<AddUserCommand>, IHandler<ActiveUserCommand>, IHandler<InactiveUserCommand>
{
    public Task Handler(AddUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task Handler(ActiveUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task Handler(InactiveUserCommand command)
    {
        throw new NotImplementedException();
    }
}