namespace DotNetTrainingBatch0.FiltersExample.Services;

public interface IExampleService
{
    Task<string> GetAsyncData();
}

public class ExampleService : IExampleService
{
    public async Task<string> GetAsyncData()
    {
        // Simulate async work
        await Task.Delay(100);
        return "Async data from service";
    }
}
