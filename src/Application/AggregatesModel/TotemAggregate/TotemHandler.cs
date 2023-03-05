using Application.Share;

namespace Application.AggregatesModel.TotemAggregate;

public class TotemHandler : IHandler<AddTotemCommand>
{
    private readonly ITotemRepository totemRepository;

    public TotemHandler(ITotemRepository totemRepository)
    {
        this.totemRepository = totemRepository;
    }

    public async Task Handler(AddTotemCommand command, CancellationToken cancellationToken = default)
    {
        var totem = new TotemModel(command.Name, command.AttendancePassword);

        await totemRepository.AddTotemAsync(totem, cancellationToken);
    }
}