using Application.AggregatesModel.ServiceDeskAggregate;
using Infrastructure.AdminContext;
using Infrastructure.ServiceContext;
using MongoDB.Driver;

namespace Infrastructure.AdminDeskContext.Repository;

public class ServiceDeskRepository : IServiceDeskRepository
{
    private readonly IMongoCollection<ServiceDesk> collection;

    public ServiceDeskRepository(IAdminDbContext context, IAdminDbConfig config)
    {
        collection = context.GetCollection<ServiceDesk>(config.ServiceDeskCollectionName);
    }

    public async Task AddServiceDeskAsync(ServiceDesk serviceDesk, CancellationToken cancellationToken = default) => 
        await collection.InsertOneAsync(serviceDesk, new(), cancellationToken);

    public async Task UpdateServiceDeskAsync(Guid id, string name, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ServiceDesk>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync(filter, Builders<ServiceDesk>.Update.Set(_ => _.Name, name));
    }


    public async Task ActiveServiceDeskAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ServiceDesk>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync(filter, Builders<ServiceDesk>.Update.Set(_ => _.Active, true));
    }


    public async Task InactiveServiceDeskAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ServiceDesk>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync(filter, Builders<ServiceDesk>.Update.Set(_ => _.Active, false));
    }

    public async Task<IEnumerable<ServiceDesk>> GetAllServiceDeskAsync(CancellationToken cancellationToken = default)
    {
        var result = await collection.FindAsync(Builders<ServiceDesk>.Filter.Empty, new(), cancellationToken);
        return result.ToList();
    }
}