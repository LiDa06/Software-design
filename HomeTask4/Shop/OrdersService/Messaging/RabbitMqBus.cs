using RabbitMQ.Client;
using System.Text;

namespace OrdersService.Messaging;
public class RabbitMqBus : IMessageBus
{
    private IConnection? _connection;

    private IConnection GetConnection()
    {
        if (_connection != null && _connection.IsOpen)
            return _connection;

        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq",
            RequestedConnectionTimeout = TimeSpan.FromSeconds(5)
        };

        _connection = factory.CreateConnection();
        return _connection;
    }

    public void Publish(string queue, string message)
    {
        var connection = GetConnection();

        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: queue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "",
            routingKey: queue,
            basicProperties: null,
            body: body
        );
    }
}
