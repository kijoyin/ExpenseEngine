using ExpenseEngine.Core.Services;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace ExpenseEngine.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IExpenseReaderService _reader;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using (var scope = _serviceProvider.CreateScope())
                {
                    var reader = scope.ServiceProvider.GetRequiredService<IExpenseReaderService>();
                    await reader.ReadStatement();
                }
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}