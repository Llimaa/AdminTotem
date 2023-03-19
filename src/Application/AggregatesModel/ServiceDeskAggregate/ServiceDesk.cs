namespace Application.AggregatesModel.ServiceDeskAggregate;

public class ServiceDesk 
{
    public ServiceDesk(string? name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Active = true;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public bool Active { get; private set; }

    public void ActiveServiceDesk() => Active = true;
    public void InactiveServiceDesk() => Active = false;
    public void UpdateName(string name) => Name = name;
}