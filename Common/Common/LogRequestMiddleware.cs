using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Common;
public class LogRequestMiddleware
{
    private readonly bool _logRequest;
    private readonly RequestDelegate _next;
    private readonly ILogger<LogRequestMiddleware> _logger;
    public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger, IConfiguration configuration)
    {
        _next = next;
        _logger = logger;
        _logRequest = configuration.GetValue<bool>("Logging:LogRequest");
    }

    public async Task Invoke(HttpContext context)
    {
        if (_logRequest)
        {
            context.Request.EnableBuffering();
            var request = context.Request;
            var logRequest = new
            {
                Route = $"({request.Method}){request.Scheme}://{request.Host}{request.Path}",
                Authorization = request.Headers.Authorization.ToString(),
                Body = Json.AddDepthToJson(await new StreamReader(request.Body).ReadToEndAsync()),
                Date=DateTime.UtcNow
            };
            _logger.LogDebug(logRequest.ToJson());

            context.Request.Body.Position = 0;
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var logResponse = new
            {
                context.Response.StatusCode,
                Body = Json.AddDepthToJson(await new StreamReader(context.Response.Body).ReadToEndAsync()),
                Date = DateTime.UtcNow,
                Duration = (DateTime.UtcNow-logRequest.Date).Seconds+ " seconds"
            };
            _logger.LogDebug(logResponse.ToJson());

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        else await _next(context);
    }
}