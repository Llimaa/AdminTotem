using Application.Share;

namespace Application.AggregatesModel.TotemAggregate;

public class TotemHandler : IHandler<AddTotemCommand>, IHandler<RemoveTotemCommand>
{
    private readonly ITotemRepository totemRepository;

    public TotemHandler(ITotemRepository totemRepository)
    {
        this.totemRepository = totemRepository;
    }

    public async Task HandlerAsync(AddTotemCommand command, CancellationToken cancellationToken = default)
    {
        var totem = new Totem(command.Name);

        await totemRepository.AddTotemAsync(totem, cancellationToken);
    }

    public async Task HandlerAsync(RemoveTotemCommand command, CancellationToken cancellationToken = default)
    {
        var id = command.Id;

        await totemRepository.RemoveTotemAsync(id, cancellationToken);
    }
}