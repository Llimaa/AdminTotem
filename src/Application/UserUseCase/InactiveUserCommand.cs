using Application.Share;

namespace Application.ServiceUseCase;

public record InactiveUserCommand : ICommand
{
    public Guid Id { get; set; }
}