namespace Application.UseCases.ServiceTotem;

public interface IServiceTotemRepository 
{
    Task<IEnumerable<ServiceTotemModel>> GetAllServiceTotemAsync(CancellationToken cancellationToken);
    Task AddServiceTotemAsync(ServiceTotemModel ServiceTotem, CancellationToken cancellationToken);
    Task ActiveServiceTotemAsync(Guid id, CancellationToken cancellationToken);
    Task InactiveServiceTotemAsync(Guid id, CancellationToken cancellationToken);

}