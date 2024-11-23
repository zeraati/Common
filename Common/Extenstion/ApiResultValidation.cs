namespace Microsoft.AspNetCore.Mvc.Filters;
public sealed class ApiResultValidation : Exception
{
    public ApiResultValidation(string message) : base(message) { }
}

public sealed class RequestFailed : Exception
{
    public RequestFailed(string? message) : base(message) { }
}

public sealed class JsonDeserializeException : Exception
{
    public JsonDeserializeException(string message, Exception exception) : base(message, exception) { }
}