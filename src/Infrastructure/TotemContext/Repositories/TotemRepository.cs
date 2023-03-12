using Application.AggregatesModel.TotemAggregate;
using Infrastructure.Config;
using Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.TotemContext.Repositories;

public class TotemRepository : ITotemRepository
{
    private readonly IMongoCollection<Totem> collection;

    public TotemRepository(ITotemDbContext totemDbContext, ITotemDbConfig totemDbConfig)
    {
        collection = totemDbContext.GetCollection<Totem>(totemDbConfig.TotemCollectionName);
    }

    public async Task<IEnumerable<Totem>> GetAllAsync(CancellationToken cancellationToken)
    {
        var filter = Builders<Totem>.Filter.Empty;

        var result = await collection
            .Aggregate()
            .Match(filter)
            .Project<Totem>(new BsonDocument 
            {
                { "_id", "$_id" },
                { "name", "$name" },
                { "active", "$active" }
            }).ToListAsync();
        
        return result;
    }

    public async Task AddTotemAsync(Totem totem, CancellationToken cancellationToken)
    {
        await collection.InsertOneAsync(totem, new(), cancellationToken);
    }

    public async Task RemoveTotemAsync(Guid id, CancellationToken cancellationToken)
    {
        await collection.DeleteOneAsync( _ => _.Id == id);
    }
}