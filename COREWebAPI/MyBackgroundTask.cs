namespace COREWebAPI
{

    //background task is a long running task that runs in the background of the application. It is used to perform tasks that are not time-sensitive and can be performed in the background without affecting the performance of the application.
    // In ASP.NET Core, you can create a background task by implementing the `IHostedService` interface or by using the `BackgroundService` class, which provides a base implementation of `IHostedService`. The `ExecuteAsync` method is where you define the logic for the background task, and it will be called when the application starts. You can use a cancellation token to gracefully stop the background task when the application is shutting down.
    public class MyBackgroundTask : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await Task.Delay(1000);

            
        }
    }

    public class MyBackgroundTask2 : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Logic to start the background task
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Logic to stop the background task
            return Task.CompletedTask;
        }
    }
}
