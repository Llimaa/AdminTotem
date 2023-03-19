namespace Infrastructure.ServiceContext;

public class AdminDbConfig : IAdminDbConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ServiceCollectionName { get; set; } = null!;
    public string TotemCollectionName { get; set; } = null!;
    public string UserCollectionName { get; set; } = null!;
    public string ServiceDeskCollectionName { get; set; } = null!;
}
