using Infrastructure.Conventions;
using Infrastructure.ServiceContext;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Infrastructure.ServiceContex;

public class ServiceDbContext : IServiceDbContext
{
    private IMongoDatabase database;
    public IMongoClient client { get; set; }

    [Obsolete]
    public ServiceDbContext(IServiceDbConfig config)
    {
        // SetUpConventions();
        client = new MongoClient(config.ConnectionString);
        database = client.GetDatabase(config.DatabaseName);
    }

    [Obsolete]
    private void SetUpConventions() 
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));


        MongoDefaults.GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard;

        var pack = new ConventionPack 
        {
            new IgnoreExtraElementsConvention(true),
            new IgnoreIfDefaultConvention(true),
            new EnumRepresentationConvention(BsonType.String),
            new SnakeCaseNameConvention()
        };

        ConventionRegistry.Register("Service Database Conventions", pack, t => true);
    }
    
    public IMongoCollection<T> GetCollection<T>(string name) => database.GetCollection<T>(name);
}