using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Mvc.Testing;
public static class WebApplicationFactoryExtension
{
    private static readonly ILogger _logger;
    static WebApplicationFactoryExtension()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _logger = loggerFactory.CreateLogger(typeof(WebApplicationFactoryExtension));
    }

    public static async Task<TResult> SendRequest<TProgram, TResult>(this WebApplicationFactory<TProgram> factory, TestClientRequest request)
        where TProgram : class
    {
        var httpRequest = request.Create();
        
        var response = await factory.CreateClient().SendAsync(httpRequest);
        if (!response.IsSuccessStatusCode)
        {
            var requestLog = new RequestLog(request.Method, request.Url, "NoAuthorization", httpRequest.Content);
            _logger.LogDebugCustom(traceId:null, "(Request Failed)", requestLog);
            throw new RequestFailed(requestLog.ToJson());
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = Json.Deserialize<TResult>(responseContent);
        return result!;
    }
}
