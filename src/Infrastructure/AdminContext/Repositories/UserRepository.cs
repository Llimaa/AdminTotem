using Application.AggregatesModel.UserAggregate;
using Infrastructure.AdminContext;
using Infrastructure.ServiceContext;
using MongoDB.Driver;

namespace Infrastructure.UserContext.Repository;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> collection;

    public UserRepository(IAdminDbContext context, IAdminDbConfig config)
    {
        collection = context.GetCollection<User>(config.UserCollectionName);
    }
    public async Task<User> GetUserByDocumentAsync(string document, CancellationToken cancellationToken)
    {
        var filter = Builders<User>.Filter.Eq(_ => _.Document, document);
        var result = await collection.FindSync<User>(filter, new(), cancellationToken).FirstOrDefaultAsync();
        return result;
    }

    public async Task AddUserAsync(User user, CancellationToken cancellationToken) => 
        await collection.InsertOneAsync(user, new(), cancellationToken);

    public async Task ActiveUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<User>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync( filter, Builders<User>.Update.Set(_ => _.Active, true));
    }

    public async Task InactiveUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<User>.Filter.Eq(_ => _.Id, id);
        await collection.UpdateOneAsync(filter, Builders<User>.Update.Set(_ => _.Active, false));
    }
}