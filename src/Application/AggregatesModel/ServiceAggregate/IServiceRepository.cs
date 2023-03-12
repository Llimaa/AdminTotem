namespace Application.AggregatesModel.ServiceAggregate;

public interface IServiceRepository 
{
    Task<IEnumerable<Service>> GetAllServiceAsync(CancellationToken cancellationToken);
    Task AddServiceTotemAsync(Service ServiceTotem, CancellationToken cancellationToken);
    Task ActiveServiceTotemAsync(Guid id, CancellationToken cancellationToken);
    Task InactiveServiceTotemAsync(Guid id, CancellationToken cancellationToken);

}