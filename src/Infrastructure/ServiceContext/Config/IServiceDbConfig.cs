namespace Infrastructure.ServiceContext;

public interface IServiceDbConfig 
{
    string ConnectionString { get; }
    string DatabaseName { get; }
    string ServiceCollectionName { get; }
}