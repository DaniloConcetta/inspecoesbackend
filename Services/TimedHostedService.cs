// learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-7.0&tabs=visual-studio
namespace Inspecoes.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer? _timer = null;
        private CancellationTokenSource? _cancellationTokenSource;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _logger.LogInformation("TimedHostedService Iniciado!");
            _timer = new Timer(ExecutarTarefa, null, TimeSpan.Zero, TimeSpan.FromDays(7));
          
            return Task.CompletedTask;
        }

        private void ExecutarTarefa(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            _logger.LogInformation("TimedHostedService Executando Tarefa!. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("TimedHostedService Interrompido!");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
          
        public void Dispose()
        {
            _timer?.Dispose();
            _cancellationTokenSource?.Dispose();
        }
    }
}
