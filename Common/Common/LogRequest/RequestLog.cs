using Microsoft.AspNetCore.Http;

namespace Common;
public class RequestLog
{
    public RequestLog(HttpMethod method,string url,string authorization, string body)
    {
        Url = $"({method}){url}";
        Authorization = authorization;
        Body = body;
    }

    public RequestLog(HttpRequest request,string body)
    {
        Url = $"({request.Method}){request.Scheme}://{request.Host}{request.Path}";
        Authorization = request.Headers.Authorization.ToString();
        Body = body;
    }

    public string Url { get; }
    public string Authorization { get; }
    public string Body { get; }
    public DateTime Date { get; }= DateTime.UtcNow;
}
