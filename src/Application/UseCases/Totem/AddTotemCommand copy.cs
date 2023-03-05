using Application.Share;

namespace Application.UseCases.Totem;

public class AddTotemCommand: ICommand 
{
    public string? Name { get; set; }
    public string? AttendancePassword { get; set; }
} 