using Microsoft.Extensions.DependencyInjection;

namespace Common;
public static class ServiceCollectionExtension
{
    public static bool IsServiceRegistered<T>(this IServiceCollection services)
        => services.Any(s => s.ServiceType == typeof(T));
}
