namespace Microsoft.AspNetCore.Mvc.Filters;
public sealed class ApiResultValidation : Exception
{
    public ApiResultValidation(string message) : base(message) { }
}