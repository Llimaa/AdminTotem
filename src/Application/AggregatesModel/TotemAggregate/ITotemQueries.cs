namespace Application.AggregatesModel.TotemAggregate;

public interface ITotemQueries 
{
    Task<IEnumerable<ResponseTotem>> GetAllTotemsAsync(CancellationToken cancellationToken);
}
