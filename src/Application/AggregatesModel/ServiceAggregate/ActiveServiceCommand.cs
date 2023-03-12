using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public record ActiveServiceCommand: ICommand
{
    public Guid Id { get; set; }
}