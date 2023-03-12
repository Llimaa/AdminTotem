using MongoDB.Driver;

namespace Infrastructure.ServiceContext;

public interface IServiceDbContext 
{
    IMongoCollection<T> GetCollection<T>(string name);
    IMongoClient client {get; set; }
}
