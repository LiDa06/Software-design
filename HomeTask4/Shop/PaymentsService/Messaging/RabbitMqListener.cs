using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PaymentsService.Messaging;

public class RabbitMqListener
{
    private readonly IConnection _connection;

    public RabbitMqListener()
    {
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq"
        };

        _connection = factory.CreateConnection();
    }

    public void Start(Func<string, Task> onMessage)
    {
        var channel = _connection.CreateModel();

        channel.QueueDeclare(
            queue: "order.created",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (_, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            await onMessage(body);
            channel.BasicAck(ea.DeliveryTag, false);
        };

        channel.BasicConsume(
            queue: "order.created",
            autoAck: false,
            consumer: consumer
        );
    }
}
