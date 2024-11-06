using System.Net;

namespace Microsoft.AspNetCore.Http;
public class ResponseLog
{
    public ResponseLog(HttpStatusCode statusCode, object? body, DateTime requestDate)
    {
        var now = DateTime.UtcNow;

        StatusCode = $"{statusCode} - {(int)statusCode}";
        Body = body;
        Duration = (now - requestDate).Seconds + " seconds";
    }

    public ResponseLog(HttpResponse response, object? body, DateTime requestDate)
    {
        var statusCode = (HttpStatusCode)response.StatusCode;
        StatusCode = $"{statusCode} - {(int)statusCode}";
        Body = body?.ToString()?.ToLower().Contains("DOCTYPE html".ToLower()) == true? "DOCTYPE html"
             : body?.ToString()?.ToLower().Contains("https://gist.github.com") == true ? "gist.github.com"
             : body?.ToString()?.ToLower().Contains("\"openapi\"") == true ? "openapi" 
             : body;
        Duration = (DateTime.UtcNow - requestDate).Seconds + " seconds";
    }

    public string StatusCode { get; }
    public object? Body { get; }
    public string Duration { get; }
}