using Csis.Common.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder;
public static class HttpRequestIServiceCollectionExtension
{
    public static IServiceCollection AddHttpRequestService(this IServiceCollection services)
    {
        services.AddHttpClient<HttpRequestService>();
        return services;
    }
}