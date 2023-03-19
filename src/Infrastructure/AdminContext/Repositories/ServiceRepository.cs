using Application.AggregatesModel.ServiceAggregate;
using Infrastructure.ServiceContext;
using MongoDB.Driver;

namespace Infrastructure.AdminContext.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly IMongoCollection<Service> collection;

    public ServiceRepository(IAdminDbContext context, IAdminDbConfig config)
    {
        collection = context.GetCollection<Service>(config.ServiceCollectionName);
    }

    public async Task<IEnumerable<Service>> GetAllServiceAsync(CancellationToken cancellationToken)
    {
        var filter = Builders<Service>.Filter.Empty;
        var result = await collection.FindAsync(filter);
        return result.ToList();
    }

    public async Task AddServiceTotemAsync(Service service, CancellationToken cancellationToken) =>
        await collection.InsertOneAsync(service, new(), cancellationToken);

    public async Task ActiveServiceTotemAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<Service>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync(filter, Builders<Service>.Update
            .Set(_ => _.Active, true)
            .Set(_ => _.UpdatedAt, DateTime.UtcNow));
    }

    public async Task InactiveServiceTotemAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<Service>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync(filter, Builders<Service>.Update
            .Set(_ => _.Active, false)
            .Set(_ => _.UpdatedAt, DateTime.UtcNow));
    }
}