
using Application.UseCases.ServiceTotem;

namespace Application.TotemUseCase;

public class TotemModel 
{
    public TotemModel(string? name, string? attendancePassword)
    {
        Id = Guid.NewGuid();
        Name = name;
        AttendancePassword = attendancePassword;
        Active = true;
        Services = new List<Service>();
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? AttendancePassword { get; private set; }
    public bool Active { get; private set; }
    public IEnumerable<Service>? Services { get; private set; }

    public void AddServices(List<ServiceTotemModel> services) 
    {
        Services = services.Select(_ => new Service(_.Id, _.Name, _.Description));
    }
}
