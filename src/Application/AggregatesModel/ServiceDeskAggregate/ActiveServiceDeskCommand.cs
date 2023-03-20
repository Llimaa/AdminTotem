
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record ActiveServiceDeskCommand: ICommand 
{
    public Guid Id { get; set; }
}
