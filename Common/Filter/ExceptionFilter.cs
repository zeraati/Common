using Common;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
        var message = MessageResource.UnmanagedException;
        var descriptor = context.ActionDescriptor.DisplayName!;

        if (context.Exception is ApiResultValidation)
        {
            message = context.Exception.Message;
        }

        if (context.Exception is DbUpdateException efException)
        {
            if (efException.InnerException is SqlException sqlException)
            {
                var exceptionInfo = sqlException.SqlExceptionInfo()!;
                _logger.LogErrorCustom(traceId, $"({nameof(SqlException)}) {descriptor}", exceptionInfo);
            }

            var entries = efException.Entries
                .ToDictionary(entry => entry.Entity.GetType().Name, entry => entry.Entity);
            _logger.LogErrorCustom(traceId, $"({nameof(DbUpdateException)}) {descriptor}", entries);
        }

        else
        {
            _logger.LogErrorCustom(traceId, descriptor, context.Exception);
        }

        var result = new ApiResultException(traceId!, message);
        context.Result = new BadRequestObjectResult(result);
    }
}
