using Application.Share;

namespace Application.AggregatesModel.TotemAggregate;

public class AddTotemCommand: ICommand 
{
    public string? Name { get; set; }
} 