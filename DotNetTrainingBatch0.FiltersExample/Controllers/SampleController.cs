using Microsoft.AspNetCore.Mvc;
using DotNetTrainingBatch0.FiltersExample.Filters;
using System.ComponentModel.DataAnnotations;

namespace DotNetTrainingBatch0.FiltersExample.Controllers;

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(LoggingActionFilter))] // Controller-level sync filter
[ServiceFilter(typeof(AsyncLoggingFilter))]   // Controller-level async filter
public class SampleController : ControllerBase
{
    [HttpGet]
    [ResponseTimeFilter] // Action-level filter
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from Filter Example API!" });
    }

    [HttpPost]
    [ValidateModel] // Custom validation filter
    public IActionResult Post([FromBody] SampleRequest request)
    {
        return Ok(new { Message = $"Received: {request.Name}" });
    }
}

public class SampleRequest
{
    [Required]
    [StringLength(10)]
    public string Name { get; set; } = string.Empty;
}
