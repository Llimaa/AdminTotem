namespace Application.AggregatesModel.TotemAggregate;

public interface ITotemRepository 
{
    Task AddTotemAsync(Totem totem, CancellationToken cancellationToken);
    Task RemoveTotemAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Totem>> GetAllAsync(CancellationToken cancellationToken);
}