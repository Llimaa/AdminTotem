
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record AddServiceDeskCommand: ICommand 
{
    public string? Name { get; set; }
}