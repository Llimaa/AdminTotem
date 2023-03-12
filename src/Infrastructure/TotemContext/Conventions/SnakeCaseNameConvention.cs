using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace Infrastructure.Conventions 
{
    public class SnakeCaseNameConvention : IMemberMapConvention
    {
        public string Name => nameof(SnakeCaseNameConvention).CamelToSnakeCase();

        public void Apply(BsonMemberMap memberMap) => memberMap.SetElementName(memberMap.MemberName.CamelToSnakeCase());
    }
}