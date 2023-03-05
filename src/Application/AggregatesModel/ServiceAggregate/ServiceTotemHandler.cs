using Application.Share;

namespace Application.AggregatesModel.ServiceAggregate;

public class ServiceTotemHandler : IHandler<AddServiceTotemCommand>, IHandler<ActiveServiceTotemCommand>, IHandler<InactiveServiceTotemCommand>
{
    private IServiceTotemRepository serviceTotemRepository;

    public ServiceTotemHandler(IServiceTotemRepository serviceTotemRepository)
    {
        this.serviceTotemRepository = serviceTotemRepository;
    }

    public async Task Handler(AddServiceTotemCommand command, CancellationToken cancellationToken = default)
    {
        var totem = new ServiceTotemModel(command.Name, command.Description);

        await serviceTotemRepository.AddServiceTotemAsync(totem, cancellationToken);
    }

    public async Task Handler(InactiveServiceTotemCommand command, CancellationToken cancellationToken = default)
    {
        var id = command.Id;

        await serviceTotemRepository.InactiveServiceTotemAsync(id, cancellationToken);
    }


    public async Task Handler(ActiveServiceTotemCommand command, CancellationToken cancellationToken = default)
    {
        var id = command.Id;
        await serviceTotemRepository.ActiveServiceTotemAsync(id, cancellationToken);
    }
}