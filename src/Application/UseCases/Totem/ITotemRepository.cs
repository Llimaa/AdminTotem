using Application.TotemUseCase;

namespace Application.UseCases.Totem;

public interface ITotemRepository 
{
    Task AddTotemAsync(TotemModel totem, CancellationToken cancellationToken);
}