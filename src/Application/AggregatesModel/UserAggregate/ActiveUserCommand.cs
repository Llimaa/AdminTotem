using Application.Share;

namespace Application.AggregatesModel.UserAggregate;

public record ActiveUserCommand: ICommand
{
    public Guid Id { get; set; }
}