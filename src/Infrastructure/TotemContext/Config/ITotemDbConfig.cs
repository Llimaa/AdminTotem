namespace Infrastructure.Config;

public interface ITotemDbConfig 
{
    string ConnectionString { get; }
    string DatabaseName { get; }
    string TotemCollectionName { get; }
}
