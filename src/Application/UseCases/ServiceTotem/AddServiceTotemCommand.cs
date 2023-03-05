using Application.Share;

namespace Application.UseCases.ServiceTotem;

public class AddServiceTotemCommand : ICommand
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; }
}