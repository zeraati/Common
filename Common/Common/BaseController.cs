namespace Microsoft.AspNetCore.Mvc;
public abstract class BaseController : ControllerBase
{
    protected new IActionResult Ok() => base.Ok(new ApiResult());
    protected IActionResult Ok(ApiResult result) => base.Ok(result);
    protected IActionResult Ok<TResult>(TResult data, string? message = null)
        => base.Ok(new ApiResult<TResult>(data: data, message: message));
    //protected IActionResult Ok<TResult>(TResult data, string message = null)
    //    => base.Ok(new ApiResultPaging<TResult>(data: data, message: message));
    //protected IActionResult Ok<TResult>(TResult data)
    //    => base.Ok(new ApiResultPaging<TResult>(data: data, metadata: metadata));

    protected IActionResult BadRequest(string message)
        => base.BadRequest(new ApiResult(success: false, message: message));
}