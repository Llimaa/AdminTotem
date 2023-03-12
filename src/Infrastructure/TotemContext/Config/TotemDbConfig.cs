namespace Infrastructure.Config;

public class TotemDbConfig: ITotemDbConfig
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TotemCollectionName { get; set; } = null!;
}