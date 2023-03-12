using Application.AggregatesModel.ServiceAggregate;

namespace Application.AggregatesModel.TotemAggregate;

public class TotemQueries : ITotemQueries
{
    private readonly ITotemRepository totemRepository;
    private readonly IServiceRepository serviceRepository;
public TotemQueries(ITotemRepository totemRepository, IServiceRepository serviceRepository)
    {
        this.totemRepository = totemRepository;
        this.serviceRepository = serviceRepository;
    }

    public async Task<IEnumerable<ResponseTotem>> GetAllTotemsAsync(CancellationToken cancellationToken)
    {
        var totems = await totemRepository.GetAllAsync(cancellationToken);

        if(totems is not null) 
        {
            var services = await serviceRepository.GetAllServiceAsync(cancellationToken);
            
            if(services is not null) 
            {
                var servicesTotem = services
                .Where(_ => _.Active)
                .Select(_ => new ServiceTotem(_.Id, _.Name, _.Description));

                var responseTotems = totems.ToList().Select(_ => new ResponseTotem(_.Id, _.Name, _.Active, servicesTotem.ToList()));
                return responseTotems;
            }
        }

        return new List<ResponseTotem>();
    }
}
