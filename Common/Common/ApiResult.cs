namespace Microsoft.AspNetCore.Mvc;
public class ApiResult : ActionResult
{
    public ApiResult(bool success = true, string? message = null)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; }
    public string? Message { get; }
}

public class ApiResultPaging<TData> : ApiResult
{
    public ApiResultPaging(TData data, Paging paging, int totalCount,bool success = true, string? message = null)
        : base(success, message)
    {
        PageSize = paging.PageSize;
        PageNumber = paging.PageNumber;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public int PageSize { get; }
    public int PageNumber { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
}