
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record InactiveServiceDeskCommand: ICommand 
{
    public Guid Id { get; set; }
}