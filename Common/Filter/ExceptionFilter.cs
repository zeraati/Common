using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc.Filters;
public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    private readonly IHttpContextAccessor _contextAccessor;
    public ExceptionFilter(ILogger<ExceptionFilter> logger, IHttpContextAccessor contextAccessor)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ApiResultValidation)
        {
            var result = new ApiResult(success: false, message: context.Exception.Message);
            context.Result = new BadRequestObjectResult(result);
        }
        else
        {
            var result = new ApiResult(success: false, message: MessageResource.UnmanagedException);
            context.Result = new BadRequestObjectResult(result);
            var descriptor = context.ActionDescriptor.DisplayName!;
            _logger.LogErrorCustom(_contextAccessor.GetTraceId(),context.Exception, descriptor: descriptor);
        }
    }
}
