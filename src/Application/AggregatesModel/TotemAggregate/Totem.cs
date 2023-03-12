
using Application.AggregatesModel.ServiceAggregate;

namespace Application.AggregatesModel.TotemAggregate;

public class Totem 
{
    public Totem(string? name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Active = true;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public bool Active { get; private set; }
}
