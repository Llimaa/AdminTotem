using Application.Share;

namespace Application.AggregatesModel.UserAggregate;

public record InactiveUserCommand : ICommand
{
    public Guid Id { get; set; }
}