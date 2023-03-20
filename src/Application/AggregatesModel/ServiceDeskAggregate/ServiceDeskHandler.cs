using Application.Share;

namespace Application.AggregatesModel.ServiceDeskAggregate;

public class ServiceDeskHandler : IHandler<AddServiceDeskCommand>, IHandler<ActiveServiceDeskCommand>, IHandler<InactiveServiceDeskCommand>, IHandler<UpdateServiceDeskCommand>
{

    private readonly IServiceDeskRepository serviceDeskRepository;

    public ServiceDeskHandler(IServiceDeskRepository serviceDeskRepository)
    {
        this.serviceDeskRepository = serviceDeskRepository;
    }

    public async Task HandlerAsync(AddServiceDeskCommand command, CancellationToken cancellationToken = default)
    {
        var serviceDesk = new ServiceDesk(command.Name);
        await serviceDeskRepository.AddServiceDeskAsync(serviceDesk);
    }

    public async Task HandlerAsync(UpdateServiceDeskCommand command, CancellationToken cancellationToken = default) => 
        await serviceDeskRepository.UpdateServiceDeskAsync(command.Id, command.Name);

    public async Task HandlerAsync(ActiveServiceDeskCommand command, CancellationToken cancellationToken = default) => 
        await serviceDeskRepository.ActiveServiceDeskAsync(command.Id);


    public async Task HandlerAsync(InactiveServiceDeskCommand command, CancellationToken cancellationToken = default) =>
        await serviceDeskRepository.InactiveServiceDeskAsync(command.Id);
}