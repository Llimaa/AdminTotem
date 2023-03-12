using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public record InactiveServiceCommand : ICommand
{
    public Guid Id { get; set; }
}