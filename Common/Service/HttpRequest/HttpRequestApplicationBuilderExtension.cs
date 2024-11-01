using Common.Service;

namespace Microsoft.Extensions.DependencyInjection;
public static class HttpRequestIServiceCollectionExtension
{
    public static IServiceCollection AddHttpRequestService(this IServiceCollection services)
    {
        services.AddHttpClient<HttpRequestService>();
        return services;
    }
}