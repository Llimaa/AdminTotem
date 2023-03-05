namespace Application.AggregatesModel.TotemAggregate;

public interface ITotemRepository 
{
    Task AddTotemAsync(TotemModel totem, CancellationToken cancellationToken);
}