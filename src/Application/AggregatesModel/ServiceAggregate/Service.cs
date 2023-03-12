namespace Application.AggregatesModel.ServiceAggregate;

public class Service 
{
    public Service(string? name, string? description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Active = true;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public bool Active { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void ActiveServiceTotem() => Active = true;
    public void InactiveServiceTotem() => Active = false;

    public void Update(string name, string description) 
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}