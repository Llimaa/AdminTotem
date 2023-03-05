using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public record InactiveServiceTotemCommand : ICommand
{
    public Guid Id { get; set; }
}