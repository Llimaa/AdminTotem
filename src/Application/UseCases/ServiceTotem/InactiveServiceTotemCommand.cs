using Application.Share;

namespace Application.UseCases.ServiceTotem;

public record InactiveServiceTotemCommand : ICommand
{
    public Guid Id { get; set; }
}