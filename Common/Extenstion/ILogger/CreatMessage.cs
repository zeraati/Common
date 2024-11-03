using System.Text;

namespace Microsoft.Extensions.Logging;
public static partial class ILoggerExtension
{
    private static string CreatMessage(Guid? traceId, object obj, string param, string callMember, string? descriptor = null, bool jsonIndented = true)
    {
        var messageLog = new StringBuilder();
        messageLog.AppendLine($"TraceId:{traceId}");
        messageLog.AppendLine($"Method:{descriptor ?? callMember} - Date:{DateTime.Now}");

        var jsonObj = ToJson(obj, jsonIndented);
        if (param == jsonObj) messageLog.AppendLine(jsonObj);
        else messageLog.AppendLine($"Param({param}): {jsonObj}");

        return messageLog.ToString() + "\n";
    }
}