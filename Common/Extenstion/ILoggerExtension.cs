using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.Logging;
public static partial class ILoggerExtension
{
    public static void LogDebugCustom(this ILogger logger, string? traceId, string descriptor,
        object? paramData = null,[CallerArgumentExpression(nameof(paramData))] string paramName = "")
    {
        logger.LogDebug(CreatMessage(traceId, descriptor, paramName, ToJson(paramData)));
    }

    public static void LogErrorCustom(this ILogger logger, string? traceId, string descriptor,
        object? paramData = null,[CallerArgumentExpression(nameof(paramData))] string paramName = "")
    {
        logger.LogError(CreatMessage(traceId, descriptor, paramName, ToJson(paramData)));
    }

    private static string CreatMessage(string? traceId, string descriptor, string? paramName, object? paramData)
    {
        var messageLog = new StringBuilder();
        messageLog.AppendLine($"TraceId:{traceId} - Date:{DateTime.Now}");
        messageLog.AppendLine($"Descriptor:{descriptor}");
        messageLog.AppendLine($"Param({paramName}): {paramData}");

        return messageLog.ToString() + "\n";
    }

    private static string? ToJson(this object? input)
    {
        if (input ==null) return null;

        var json=Json.Serialize(input)!;
        var document = JsonDocument.Parse(json);
        var result = System.Text.Json.JsonSerializer.Serialize(document, new JsonSerializerOptions { WriteIndented = true });
        return result;
    }
}