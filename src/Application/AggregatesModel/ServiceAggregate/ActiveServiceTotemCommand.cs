using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public record ActiveServiceTotemCommand: ICommand
{
    public Guid Id { get; set; }
}