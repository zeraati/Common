using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Common;
public class RequestLog
{
    public RequestLog(HttpMethod method,string url,string authorization, string body, bool jsonIndented = true)
    {
        Url = $"({method}){url}";
        Authorization = authorization;
        Body = TryToJsonDocument(body);
    }

    public RequestLog(HttpRequest request,string body, bool jsonIndented = true)
    {
        Url = $"({request.Method}){request.Scheme}://{request.Host}{request.Path}";
        Authorization = request.Headers.Authorization.ToString();
        Body = TryToJsonDocument(body);
    }

    public string Url { get; }
    public string Authorization { get; }
    public object? Body { get; }
    public DateTime Date { get; }= DateTime.UtcNow;

    private static object TryToJsonDocument(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        try { return JsonDocument.Parse(input); }
        catch (Exception) { return input; }
    }
}
