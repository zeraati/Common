namespace Microsoft.AspNetCore.Http;
public class RequestLog
{
    public RequestLog(HttpMethod method,string url,string authorization, object? body)
    {
        Url = $"({method}){url}";
        Authorization = authorization;
        Body = body;
    }

    public RequestLog(HttpRequest request, object? body)
    {
        Url = $"({request.Method}){request.Scheme}://{request.Host}{request.Path}";
        Authorization = request.Headers.Authorization.ToString();
        Body = body;
    }

    public string Url { get; }
    public string Authorization { get; }
    public object? Body { get; }
}
