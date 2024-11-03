﻿using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.Logging;
public static partial class ILoggerExtension
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
}