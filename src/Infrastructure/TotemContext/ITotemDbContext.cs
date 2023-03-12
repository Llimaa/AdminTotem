using MongoDB.Driver;

namespace Infrastructure.Context;

public interface ITotemDbContext 
{
    IMongoCollection<T> GetCollection<T>(string name);
    IMongoClient client { get; set; }
}
