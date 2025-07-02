using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace Erdmier.TagVault.Application.Common.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);

        // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
