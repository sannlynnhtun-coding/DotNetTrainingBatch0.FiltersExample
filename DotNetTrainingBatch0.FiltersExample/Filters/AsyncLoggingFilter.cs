using Microsoft.AspNetCore.Mvc.Filters;
using DotNetTrainingBatch0.FiltersExample.Services;

namespace DotNetTrainingBatch0.FiltersExample.Filters;

public class AsyncLoggingFilter : IAsyncActionFilter
{
    private readonly ILogger<AsyncLoggingFilter> _logger;
    private readonly IExampleService _exampleService;

    public AsyncLoggingFilter(ILogger<AsyncLoggingFilter> logger, IExampleService exampleService)
    {
        _logger = logger;
        _exampleService = exampleService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Before action
        _logger.LogInformation("Async Filter: Before execution");
        
        var data = await _exampleService.GetAsyncData();
        _logger.LogInformation("Async Filter: Service data: {Data}", data);

        // Execute the action
        var resultContext = await next();

        // After action
        _logger.LogInformation("Async Filter: After execution");
    }
}
