using PaymentsService.Messaging;

namespace PaymentsService.Consumers;

public class OrderCreatedConsumer(RabbitMqListener listener) : BackgroundService
{
    private readonly RabbitMqListener _listener = listener;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _listener.Start(async message =>
        {
            try
            {
                Console.WriteLine($"Payment received: {message}");

                await Task.Delay(500);

                Console.WriteLine("Payment processed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Payment error: {ex.Message}");
            }
        });

        return Task.CompletedTask;
    }
}
