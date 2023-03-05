using Application.Share;

namespace Application.UseCases.ServiceTotem;

public record ActiveServiceTotemCommand: ICommand
{
    public Guid Id { get; set; }
}