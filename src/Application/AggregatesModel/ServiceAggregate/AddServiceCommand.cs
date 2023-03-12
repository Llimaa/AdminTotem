using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public class AddServiceCommand : ICommand
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; }
}