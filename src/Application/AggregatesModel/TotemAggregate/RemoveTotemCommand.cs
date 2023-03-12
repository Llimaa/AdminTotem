using Application.Share;

namespace Application.AggregatesModel.TotemAggregate;

public class RemoveTotemCommand: ICommand 
{
    public Guid Id { get; set; }
} 