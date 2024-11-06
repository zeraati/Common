using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Common;
public class RequestLogMiddleware
{
    private readonly bool _logRequest;
    private readonly RequestDelegate _next;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<RequestLogMiddleware> _logger;
    public RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger, 
        IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _next = next;
        _logger = logger;
        _contextAccessor = contextAccessor;
        _logRequest = configuration.GetValue<bool>("Logging:RequestLogging:Active");
    }

    public async Task Invoke(HttpContext context)
    {
        if (_logRequest)
        {
            var traceId=_contextAccessor.GetTraceId();
            var descriptor = "";

            context.Request.EnableBuffering();
            var request = context.Request;
            var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var logRequest = new RequestLog(request, requestBody);
            _logger.LogDebugCustom(traceId, descriptor,logRequest);

            context.Request.Body.Position = 0;
            var originalBodyStream = context.Response.Body;
            using var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var responseBody= await new StreamReader(context.Response.Body).ReadToEndAsync();
            var logResponse = new ResponseLog(context.Response, responseBody, logRequest.Date);
            _logger.LogDebugCustom(traceId, descriptor, logResponse);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(originalBodyStream);
        }
        else await _next(context);
    }
}