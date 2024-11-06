using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Common;
public class ResponseLog
{
    public ResponseLog(HttpStatusCode statusCode, string body, DateTime requestDate, bool jsonIndented = true)
    {
        var now = DateTime.UtcNow;

        StatusCode = $"{statusCode} - {(int)statusCode}";
        Body = TryToJsonDocument(body);
        Date = now;
        Duration = (now - requestDate).Seconds + " seconds";
    }

    public ResponseLog(HttpResponse response, string body, DateTime requestDate, bool jsonIndented = true)
    {
        var now = DateTime.UtcNow;

        var statusCode = (HttpStatusCode)response.StatusCode;
        StatusCode = $"{statusCode} - {(int)statusCode}";
        Body = body.ToLower().Contains("DOCTYPE html".ToLower()) == true? "DOCTYPE html"
             : body.ToLower().Contains("https://gist.github.com".ToLower()) == true ? "gist.github.com"
             : body.ToLower().Contains("\"openapi\"".ToLower()) == true ? "openapi" 
             : TryToJsonDocument(body);
        Date = now;
        Duration = (now - requestDate).Seconds + " seconds";
    }

    public string StatusCode { get; }
    public object? Body { get; }
    public DateTime Date { get; }
    public string Duration { get; }

    private static object TryToJsonDocument(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        try { return JsonDocument.Parse(input); }
        catch (Exception) { return input; }
    }
}