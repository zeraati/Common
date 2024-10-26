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

public class ApiResult<TData> : ApiResult
{
    public ApiResult(TData data, bool success = true, string? message = null) : base(success, message)
    {
        Data = data;
    }

    public TData? Data { get; }
}

public class ApiResultPaging<TData> : ApiResult<TData>
{
    public ApiResultPaging(TData data, Paging paging, int totalCount, bool success = true, string? message = null)
        : base(data,success, message)
    {
        Pagination = new(paging, totalCount);
    }

    public Pagination Pagination { get; set; }
    
}

public class Pagination(Paging paging, int totalCount)
{
    public int PageSize { get; }=paging.PageSize;
    public int PageNumber { get; } = paging.PageNumber;
    public int TotalCount { get; }=totalCount;
    public int TotalPages { get; }= (int)Math.Ceiling((double)totalCount / paging.PageSize);
}