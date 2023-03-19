namespace Infrastructure.ServiceContext;

public interface IAdminDbConfig 
{
    string ConnectionString { get; }
    string DatabaseName { get; }
    string ServiceCollectionName { get; }
    string TotemCollectionName { get; }
    string UserCollectionName { get; }
    string ServiceDeskCollectionName { get; }
}
