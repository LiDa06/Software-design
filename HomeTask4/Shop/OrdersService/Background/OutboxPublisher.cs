using OrdersService.Data;

namespace OrdersService.Background;
public class OutboxPublisher(IServiceScopeFactory scopeFactory, IMessageBus bus) : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly IMessageBus _bus = bus;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();

                var messages = db.Outbox
                    .Where(x => !x.Processed)
                    .ToList();

                foreach (var msg in messages)
                {
                    _bus.Publish("order.created", msg.Payload);
                    msg.Processed = true;
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outbox error: {ex.Message}");
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
