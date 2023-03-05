using Application.Share;

namespace Application.ServiceUseCase;

public record ActiveUserCommand: ICommand
{
    public Guid Id { get; set; }
}