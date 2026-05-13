# Filters Example - ASP.NET Core

This project demonstrates the usage of **Filters** in ASP.NET Core to inject logic at specific stages of the MVC/API action invocation pipeline.

## Project Overview

Filters allow you to run code before or after specific stages in the request processing pipeline. This project covers:
- **Action Filters**: Running logic before and after an action method executes.
- **Async Action Filters**: Asynchronous implementation of action filters.
- **Result Filters**: Handling logic around the execution of the action result.
- **Model Validation**: Using filters to centralize `ModelState` validation.

## Filter Types Included

1.  **ResponseTimeFilter**: A global filter that calculates and logs the time taken for an action to execute.
2.  **LoggingActionFilter**: A synchronous action filter that logs when an action starts and ends.
3.  **AsyncLoggingFilter**: An asynchronous version of the logging filter, demonstrating how to use `ActionExecutionDelegate`.
4.  **ValidateModelAttribute**: A custom attribute filter that automatically returns a `400 Bad Request` if the model state is invalid.

## Step-by-Step Flow

The execution order of filters in this project is as follows:

1.  **Global Filters**: The `ResponseTimeFilter` starts (registered in `Program.cs`).
2.  **Controller Filters**: The `LoggingActionFilter` and `AsyncLoggingFilter` (applied via `[ServiceFilter]` on `SampleController`) begin execution.
3.  **Action Filters**: If the action has specific filters (like `[ValidateModel]`), they execute next.
4.  **Model Validation**: `ValidateModelAttribute` checks if the `SampleRequest` body is valid. If invalid, it short-circuits the request and returns a `400` error immediately.
5.  **Action Execution**: The controller's action method (e.g., `Get` or `Post`) runs.
6.  **Post-Action Logic**: All filters then execute their "after" logic in reverse order, finishing with the `ResponseTimeFilter` logging the total duration.

## How to Run

1.  Open the solution file `DotNetTrainingBatch0.FiltersExample.slnx` or the project folder.
2.  Run the project using `dotnet run`.
3.  Navigate to the Scalar API documentation at `https://localhost:7199/scalar/v1` (port may vary) to test the endpoints.
