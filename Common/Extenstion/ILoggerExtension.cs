using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.Logging;
public static class ILoggerExtension
{
    public static void LogDebugCustom(this ILogger logger, object obj, bool jsonIndented = true
        , [CallerArgumentExpression(nameof(obj))] string param = "", [CallerMemberName] string callMember = "")
    {
        logger.LogDebug(CreatMessage(obj, param, callMember, jsonIndented:jsonIndented));
    }

    public static void LogErrorCustom(this ILogger logger, object obj, bool jsonIndented = true, string? descriptor = null,
        [CallerArgumentExpression(nameof(obj))] string param = "", [CallerMemberName] string callMember = "")
    {
        logger.LogError(CreatMessage(obj, param, callMember, descriptor, jsonIndented));
    }

    private static string CreatMessage(object obj, string param, string callMember, string? descriptor = null, bool jsonIndented = true)
    {
        var messageLog = new StringBuilder();
        messageLog.AppendLine($"Method:{descriptor ?? callMember} - Date:{DateTime.Now}");

        var jsonObj = ToJson(obj, jsonIndented);
        if (param == jsonObj) messageLog.AppendLine(jsonObj);
        else messageLog.AppendLine($"Param({param}): {jsonObj}");

        return messageLog.ToString() + "\n";
    }

    private static string ToJson(object obj, bool jsonIndented = true, string? descriptor = null)
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