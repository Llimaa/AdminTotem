
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record ActiveServiceDesk: ICommand 
{
    public Guid Id { get; set; }
}
