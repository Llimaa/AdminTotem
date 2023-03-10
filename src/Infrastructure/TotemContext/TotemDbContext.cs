using Infrastructure.Config;
using Infrastructure.Conventions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Infrastructure.Context;

public class TotemDbContext: ITotemDbContext
{
    private IMongoDatabase database { get; set; }
    public IMongoClient client { get; set; }

    [Obsolete]
    public TotemDbContext(ITotemDbConfig config)
    {
        SetUpConventions();
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

        ConventionRegistry.Register("Totem Database Conventions", pack, t => true);
    }
    public IMongoCollection<T> GetCollection<T>(string name) => database.GetCollection<T>(name);
}