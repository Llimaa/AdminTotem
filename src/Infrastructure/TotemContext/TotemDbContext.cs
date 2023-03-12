using Infrastructure.Config;
using Infrastructure.Conventions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Infrastructure.Context;

public class TotemDbContext: ITotemDbContext
{
    private IMongoDatabase database { get; set; }
    public IMongoClient client { get; set; }

    public TotemDbContext(ITotemDbConfig config)
    {
        SetUpConventions();
        client = new MongoClient(config.ConnectionString);
        database = client.GetDatabase(config.DatabaseName);
    }

    private void SetUpConventions() 
    {
        var pack = new ConventionPack 
        {
            new IgnoreExtraElementsConvention(true),
            new IgnoreIfDefaultConvention(true),
            new EnumRepresentationConvention(BsonType.String),
            new SnakeCaseNameConvention()
        };
    }
    public IMongoCollection<T> GetCollection<T>(string name) => database.GetCollection<T>(name);
}