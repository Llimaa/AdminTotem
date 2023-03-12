using Infrastructure.Config;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddInfrastructure 
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration) 
    {
        services.Configure<TotemDbConfig>(configuration.GetSection(nameof(TotemDbConfig)));
        services.AddTransient<ITotemDbConfig, TotemDbConfig>( _ => _.GetRequiredService<IOptions<TotemDbConfig>>().Value);
        services.AddSingleton<ITotemDbContext, TotemDbContext>();
    }
}