using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Common;
public class RequestLog
{
    public RequestLog(HttpMethod method,string url,string authorization, string body, bool jsonIndented = true)
    {
        Url = $"({method}){url}";
        Authorization = authorization;
        Body = JsonDocument.Parse(body)!;
    }

    public RequestLog(HttpRequest request,string body, bool jsonIndented = true)
    {
        Url = $"({request.Method}){request.Scheme}://{request.Host}{request.Path}";
        Authorization = request.Headers.Authorization.ToString();
        Body = JsonDocument.Parse(body)!;
    }

    public string Url { get; }
    public string Authorization { get; }
    public object Body { get; }
    public DateTime Date { get; }= DateTime.UtcNow;
}
