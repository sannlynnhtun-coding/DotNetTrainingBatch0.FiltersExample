using DotNetTrainingBatch0.FiltersExample.Filters;
using DotNetTrainingBatch0.FiltersExample.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    // 1. GLOBAL FILTER REGISTRATION
    // This will run for EVERY controller action in the application.
    options.Filters.Add<ResponseTimeFilter>(); 
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register services for DI
builder.Services.AddScoped<IExampleService, ExampleService>();

// Register filters for DI (if using ServiceFilter)
builder.Services.AddScoped<LoggingActionFilter>();
builder.Services.AddScoped<AsyncLoggingFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Add Scalar
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Enable Controllers
app.MapControllers();

app.Run();
