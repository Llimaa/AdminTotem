
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record AddServiceDesk: ICommand 
{
    public string? Name { get; set; }
}