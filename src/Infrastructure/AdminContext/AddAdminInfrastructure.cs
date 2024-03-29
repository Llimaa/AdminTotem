using Application.AggregatesModel.ServiceAggregate;
using Application.AggregatesModel.ServiceDeskAggregate;
using Application.AggregatesModel.TotemAggregate;
using Application.AggregatesModel.UserAggregate;
using Infrastructure.AdminContext;
using Infrastructure.AdminContext.Repositories;
using Infrastructure.AdminDeskContext.Repository;
using Infrastructure.ServiceContext;
using Infrastructure.TotemContext.Repositories;
using Infrastructure.UserContext.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddAdminInfrastructure 
{
    public static void AddAdminDependencies( this IServiceCollection services, IConfiguration configuration) 
    {
        services.Configure<AdminDbConfig>(configuration.GetSection(nameof(AdminDbConfig)));
        services.AddTransient<IAdminDbConfig, AdminDbConfig>(_ => _.GetRequiredService<IOptions<AdminDbConfig>>().Value);
        services.AddSingleton<IAdminDbContext, AdminDbContext>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IServiceDeskRepository, ServiceDeskRepository>();
        services.AddScoped<ITotemRepository, TotemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}