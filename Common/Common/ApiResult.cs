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
        : base(data, success, message)
    {
        Pagination = new(paging, totalCount);
    }

    public PaginationData Pagination { get; set; }

    public class PaginationData(Paging paging, int totalCount)
    {
        public int PageSize { get; } = paging.PageSize;
        public int PageNumber { get; } = paging.PageNumber;
        public int TotalCount { get; } = totalCount;
        public int TotalPages { get; } = (int)Math.Ceiling((double)totalCount / paging.PageSize);
    }
}

public class ApiResultException : ApiResult
{
    public ApiResultException(string traceId, string? message = null) 
        : base(success:false, message)
    {
        TraceId = traceId;
    }
    public string TraceId { get; }
}