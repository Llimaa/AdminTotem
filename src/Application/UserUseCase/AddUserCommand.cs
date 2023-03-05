using Application.Share;

namespace Application.UserUseCases;

public class AddUserCommand: ICommand
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
}