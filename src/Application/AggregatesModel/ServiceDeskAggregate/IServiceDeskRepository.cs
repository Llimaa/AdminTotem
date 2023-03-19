namespace Application.AggregatesModel.ServiceDeskAggregate;

public interface IServiceDeskRepository 
{
    Task AddServiceDeskAsync(ServiceDesk serviceDesk, CancellationToken cancellationToken = default);
    Task UpdateServiceDeskAsync(Guid id, string name, CancellationToken cancellationToken = default);
    Task ActiveServiceDeskAsync(Guid id, CancellationToken cancellationToken = default);
    Task InactiveServiceDeskAsync(Guid id, CancellationToken cancellationToken = default);
}