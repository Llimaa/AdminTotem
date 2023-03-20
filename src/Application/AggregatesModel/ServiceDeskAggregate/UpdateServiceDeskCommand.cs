
using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public record UpdateServiceDeskCommand: ICommand 
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
