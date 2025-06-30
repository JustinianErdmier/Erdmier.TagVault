using Erdmier.DomainCore.MediatorCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Persistence.Contexts;

namespace Persistence.Common.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddApplicationDbContext(configuration, environment);
        services.AddScoped<PublishDomainEventsInterceptor>();

        return services;
    }

    private static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        string connectionString = configuration[ApplicationDbContext.ConnectionStringKey]
                                  ?? throw new InvalidOperationException($"Connection string `{ApplicationDbContext.ConnectionStringKey}` not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }

            options.UseSqlServer(connectionString,
                                 sqlServerOptions =>
                                 {
                                     sqlServerOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);

                                     sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                                 });
        });

        return services;
    }
}
