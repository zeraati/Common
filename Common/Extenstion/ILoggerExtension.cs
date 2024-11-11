using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Common;
public static partial class ILoggerExtension
{
    public static void LogDebugCustom(this ILogger logger, string? traceId, string descriptor,
        object paramData, [CallerArgumentExpression(nameof(paramData))] string paramName = "")
    {
        Console.WriteLine("\n==================================================================================\n");
        logger.LogDebug(CreatContent(traceId, descriptor, paramName, paramData));
        Console.WriteLine("\n==================================================================================\n");
    }

    public static void LogErrorCustom(this ILogger logger, string? traceId, string descriptor,
        object paramData, [CallerArgumentExpression(nameof(paramData))] string paramName = "")
    {
        Console.WriteLine("\n==================================================================================\n");
        logger.LogError(CreatContent(traceId, descriptor, paramName, paramData));
        Console.WriteLine("\n==================================================================================\n");
    }

    private static string CreatContent(string? traceId, string descriptor, string paramName, object paramData)
    {
        var content = new Dictionary<string, object?>
        {
            { nameof(traceId), traceId },
            { "date", DateTime.UtcNow },
            { nameof(descriptor), descriptor }
        };

        if (paramData is Exception)
        {
            var data = Json.Deserialize<Dictionary<string, object>>(paramData.ToJson())!;

            //var message = data["Message"];
            data.Remove("StackTraceString");
            paramData = data;
        }
        content.Add(paramName, paramData);


        return JsonConvert.SerializeObject(content, Formatting.Indented);
    }
}