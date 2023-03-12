using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public class ServiceHandler : IHandler<AddServiceCommand>, IHandler<ActiveServiceCommand>, IHandler<InactiveServiceCommand>
{
    private IServiceRepository serviceTotemRepository;

    public ServiceHandler(IServiceRepository serviceTotemRepository)
    {
        this.serviceTotemRepository = serviceTotemRepository;
    }

    public async Task HandlerAsync(AddServiceCommand command, CancellationToken cancellationToken = default)
    {
        var totem = new Service(command.Name, command.Description);

        await serviceTotemRepository.AddServiceTotemAsync(totem, cancellationToken);
    }

    public async Task HandlerAsync(InactiveServiceCommand command, CancellationToken cancellationToken = default)
    {
        var id = command.Id;

        await serviceTotemRepository.InactiveServiceTotemAsync(id, cancellationToken);
    }


    public async Task HandlerAsync(ActiveServiceCommand command, CancellationToken cancellationToken = default)
    {
        var id = command.Id;
        await serviceTotemRepository.ActiveServiceTotemAsync(id, cancellationToken);
    }
}