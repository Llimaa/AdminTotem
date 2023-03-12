namespace Infrastructure.ServiceContext;

public class ServiceDbConfig : IServiceDbConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ServiceCollectionName { get; set; } = null!;
}