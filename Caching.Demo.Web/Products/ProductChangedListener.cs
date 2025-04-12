
using Npgsql;

namespace Caching.Demo.Web.Products
{
    public class ProductChangedListener : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductChangedListener> logger;
        private const string channelName = "product_changed";

        public ProductChangedListener(IConfiguration configuration, ILogger<ProductChangedListener> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var conn = new NpgsqlConnection(configuration.GetConnectionString("postgres-container")))
            {
                await conn.OpenAsync(stoppingToken);
                conn.Notification += (o, e) =>
                {
                    logger.LogInformation("Product changed: {payload}", e.Payload);
                };

                using (var cmd = new NpgsqlCommand($"LISTEN {channelName}", conn))
                {
                    await cmd.ExecuteNonQueryAsync(stoppingToken);
                    logger.LogInformation("Listening for product changes...");
                }

                while (!stoppingToken.IsCancellationRequested)
                {
                    await conn.WaitAsync(stoppingToken);
                }
            }

        }
    }
}
