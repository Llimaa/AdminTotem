using Application.AggregatesModel.TotemAggregate;
using Infrastructure.Config;
using Infrastructure.Context;
using Infrastructure.TotemContext.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddTotemInfrastructure 
{
    public static void AddTotemDependencies(this IServiceCollection services, IConfiguration configuration) 
    {
        services.Configure<TotemDbConfig>(configuration.GetSection(nameof(TotemDbConfig)));
        services.AddTransient<ITotemDbConfig, TotemDbConfig>( _ => _.GetRequiredService<IOptions<TotemDbConfig>>().Value);
        services.AddSingleton<ITotemDbContext, TotemDbContext>();
        services.AddScoped<ITotemRepository, TotemRepository>();
    }
}