using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Common;
public class ResponseLog
{
    public ResponseLog(HttpStatusCode statusCode, string body, DateTime requestDate,bool jsonIndented = true)
    {
        var now = DateTime.UtcNow;

        StatusCode = $"{statusCode} - {(int)statusCode}";
        Body = JsonDocument.Parse(body)!;
        Date = now;
        Duration = (now - requestDate).Seconds + " seconds";
    }

    public ResponseLog(HttpResponse response, string body,DateTime requestDate, bool jsonIndented = true)
    {
        var now=DateTime.UtcNow;

        var statusCode = (HttpStatusCode)response.StatusCode;
        StatusCode = $"{statusCode} - {(int)statusCode}";
        Body = JsonDocument.Parse(body)!;
        Date = now;
        Duration = (now - requestDate).Seconds + " seconds";
    }

    public string StatusCode { get;}
    public object Body { get; }
    public DateTime Date { get; }
    public string Duration { get; }
}