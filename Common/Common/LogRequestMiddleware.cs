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
            var requestBodyLog = await new StreamReader(request.Body).ReadToEndAsync();
            var logRequest = new RequestLog(request, requestBodyLog);
            _logger.LogDebug(logRequest.ToJson());

            context.Request.Body.Position = 0;
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var responseBodyLog= await new StreamReader(context.Response.Body).ReadToEndAsync();
            var logResponse = new ResponseLog(context.Response, responseBodyLog, logRequest.Date);
            _logger.LogDebug(logResponse.ToJson());

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        else await _next(context);
    }
}

#pragma warning disable CS8618
public class RequestLog
{
    public RequestLog(HttpRequest request,string body)
    {
        Url = $"({request.Method}){request.Scheme}://{request.Host}{request.Path}";
        Authorization = request.Headers.Authorization.ToString();
        Body = Json.AddDepthToJson(body);
    }

    public string Url { get; }
    public string Authorization { get; }
    public string Body { get; }
    public DateTime Date { get; }= DateTime.UtcNow;
}

public class ResponseLog
{
    public ResponseLog(HttpResponse response, string body,DateTime requestDate)
    {
        var now=DateTime.UtcNow;

        StatusCode = response.StatusCode;
        Body = Json.AddDepthToJson(body);
        Date = now;
        Duration = (now - requestDate).Seconds + " seconds";
    }

    public int StatusCode { get;}
    public string Body { get; }
    public DateTime Date { get; }
    public string Duration { get; }
}