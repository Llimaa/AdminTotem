using Application.AggregatesModel.ServiceAggregate;
using Infrastructure.ServiceContex;
using Infrastructure.ServiceContex.Repositories;
using Infrastructure.ServiceContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddServiceInfrastructure 
{
    public static void AddServiceDependencies( this IServiceCollection services, IConfiguration configuration) 
    {
        services.Configure<ServiceDbConfig>(configuration.GetSection(nameof(ServiceDbConfig)));
        services.AddTransient<IServiceDbConfig, ServiceDbConfig>(_ => _.GetRequiredService<IOptions<ServiceDbConfig>>().Value);
        services.AddSingleton<IServiceDbContext, ServiceDbContext>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
    }
}