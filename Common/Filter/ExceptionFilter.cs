using Common;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        var traceId = _contextAccessor.GetTraceId();
        var descriptor = context.ActionDescriptor.DisplayName!;

        if (context.Exception is ApiResultValidation)
        {
            dynamic result = new ApiResult(success: false, message: context.Exception.Message);
            result.TraceId = traceId;
            context.Result = new BadRequestObjectResult(result);
        }

        if (context.Exception is DbUpdateException efException)
        {
            if (efException.InnerException is SqlException sqlException)
            {
                var exceptionInfo = sqlException.SqlExceptionInfo();
                _logger.LogErrorCustom(traceId, descriptor,exceptionInfo);
            }
                
            var entries = new Dictionary<string, object>();
            foreach (var entry in efException.Entries)
            {
                var name = entry.Entity.GetType().Name;
                var data = Json.AddDepthToJson(entry.Entity.ToJson()!);
                entries.Add(name, data);
            }

            _logger.LogErrorCustom(traceId, descriptor,entries);
        }

        else
        {
            var result = new ApiResult(success: false, message: MessageResource.UnmanagedException);
            context.Result = new BadRequestObjectResult(result);
            _logger.LogErrorCustom(traceId, descriptor,context.Exception);
        }
    }
}
