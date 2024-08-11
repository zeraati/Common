using System.Diagnostics;

namespace Microsoft.Extensions.Logging;
public static class ILoggerExtension
{
    public static void LogInformationCustom<T>(this ILogger<T> logger, LogMessage logMessage) => LogInformation(logger, logMessage);

    public static void LogInformationCustom<T>(this ILogger<T> logger, LogMessage logMessage, string message) => LogInformation(logger, logMessage, message, null);
    public static void LogInformationCustom<T>(this ILogger<T> logger, LogMessage logMessage, object request) => LogInformation(logger, logMessage, null, request);
    public static void LogInformationCustom<T>(this ILogger<T> logger, LogMessage logMessage, string message, object? request = null) => LogInformation(logger, logMessage, message, request);

    public static void LogInformationCustom<T>(this ILogger<T> logger, LogMessage logMessage, string message, Stopwatch stopwatch)
    {
        message += $" in {stopwatch.ElapsedMilliseconds} ms";
        LogInformation(logger, logMessage, message);
    }

    private static void LogInformation<T>(ILogger<T> logger, LogMessage logMessage, string? message = null, object? request = null)
    {
        var @class = typeof(T)!.Name.Replace("`2", "");

        if (string.IsNullOrEmpty(message)) message = ", " + message;
        message = $"{logMessage} {@class} {message}";

        if (request != null) message += ", Request: " + Util.Json.Serialize(request);

        logger.Log(LogLevel.Information, message);
    }
}

public enum LogMessage
{
    Handling,
    Handled
}