using Microsoft.AspNetCore.Http;
public static class IHttpContextAccessorExtension
{
    public static string? GetTraceId(this IHttpContextAccessor accessor) => accessor.HttpContext?.TraceIdentifier;
}

