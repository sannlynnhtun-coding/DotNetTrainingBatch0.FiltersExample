using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace DotNetTrainingBatch0.FiltersExample.Filters;

public class ResponseTimeFilter : ActionFilterAttribute
{
    private Stopwatch? _stopwatch;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch?.Stop();
        context.HttpContext.Response.Headers.Append("X-Action-Duration-ms", _stopwatch?.ElapsedMilliseconds.ToString());
    }
}
