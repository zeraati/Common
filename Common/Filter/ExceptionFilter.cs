using Common;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc.Filters;
public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    public ExceptionFilter(ILogger<ExceptionFilter> logger) => _logger = logger;

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
            _logger.LogErrorCustom(context.Exception, descriptor: descriptor);
        }
    }
}
