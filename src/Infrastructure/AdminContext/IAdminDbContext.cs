using MongoDB.Driver;

namespace Infrastructure.AdminContext;

public interface IAdminDbContext 
{
    IMongoCollection<T> GetCollection<T>(string name);
    IMongoClient client {get; set; }
}
