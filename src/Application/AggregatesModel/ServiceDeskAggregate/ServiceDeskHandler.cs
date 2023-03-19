using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public class ServiceDeskHandler : IHandler<AddServiceDesk>, IHandler<ActiveServiceDesk>, IHandler<InactiveServiceDesk>, IHandler<UpdateServiceDesk>
{

    private readonly IServiceDeskRepository serviceDeskRepository;

    public ServiceDeskHandler(IServiceDeskRepository serviceDeskRepository)
    {
        this.serviceDeskRepository = serviceDeskRepository;
    }

    public async Task HandlerAsync(AddServiceDesk command, CancellationToken cancellationToken = default)
    {
        var serviceDesk = new ServiceDesk(command.Name);
        await serviceDeskRepository.AddServiceDeskAsync(serviceDesk);
    }

    public async Task HandlerAsync(UpdateServiceDesk command, CancellationToken cancellationToken = default) => 
        await serviceDeskRepository.UpdateServiceDeskAsync(command.Id, command.Name);

    public async Task HandlerAsync(ActiveServiceDesk command, CancellationToken cancellationToken = default) => 
        await serviceDeskRepository.ActiveServiceDeskAsync(command.Id);


    public async Task HandlerAsync(InactiveServiceDesk command, CancellationToken cancellationToken = default) =>
        await serviceDeskRepository.InactiveServiceDeskAsync(command.Id);
}