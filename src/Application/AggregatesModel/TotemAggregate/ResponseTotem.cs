namespace Application.AggregatesModel.TotemAggregate;

public class ResponseTotem 
{
    public ResponseTotem(Guid id, string? name, bool active, List<ServiceTotem>? services)
    {
        Id = id;
        Name = name;
        Active = active;
        Services = services;
    }

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool Active { get; set; }
    public List<ServiceTotem>? Services { get; set; }
}