namespace GamesLibrary.HostedServices
{
    public class AppInitService : IHostedService
    {
        public AppInitService() { }

        public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
