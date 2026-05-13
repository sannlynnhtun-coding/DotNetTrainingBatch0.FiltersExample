using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetTrainingBatch0.FiltersExample.Filters;

public class LoggingActionFilter : IActionFilter
{
    private readonly ILogger<LoggingActionFilter> _logger;

    public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Before action
        _logger.LogInformation("Action Filter: Executing {Action}", context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // After action
        _logger.LogInformation("Action Filter: Executed {Action}", context.ActionDescriptor.DisplayName);
    }
}
