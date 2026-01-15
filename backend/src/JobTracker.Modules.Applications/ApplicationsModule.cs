using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobTracker.Modules.Applications;

public static class ApplicationsModule
{
    public static IServiceCollection AddApplicationsModule(this IServiceCollection services, IConfiguration configuration)
    {
        // later: DbContext, repositories, handlers, validators, etc.
        return services;
    }

    public static Assembly Assembly => typeof(ApplicationsModule).Assembly;
}
