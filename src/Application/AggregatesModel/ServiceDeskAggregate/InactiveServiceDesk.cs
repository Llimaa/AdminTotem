
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record InactiveServiceDesk: ICommand 
{
    public Guid Id { get; set; }
}