using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Extensions.Logging;
public static partial class ILoggerExtension
{
    private static string ToJson(object obj, bool jsonIndented = true)
    {
        if (obj == null) return "";
        if (obj is string) return (obj as string)!;
        if (obj is Exception)
        {
            if(obj is HttpRequestException) return (obj as HttpRequestException)!.Message;
            return obj.ToString()!;
        }
        if (obj.ToString()!.StartsWith("{") || obj.ToString()!.StartsWith("[")) return obj.ToString()!;

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            MaxDepth = 16,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = jsonIndented
        };

        try
        {
            var json = JsonSerializer.Serialize(obj, options);
            return json;
        }
        catch (Exception exception)
        {
            return exception.ToString();
        }
    }
}