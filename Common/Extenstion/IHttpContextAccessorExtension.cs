using Microsoft.AspNetCore.Http;

namespace Common;
public static class IHttpContextAccessorExtension
{
    public static Guid? GetTraceId(this IHttpContextAccessor accessor) 
        => Guid.Parse(accessor.HttpContext?.TraceIdentifier ?? "");
}

