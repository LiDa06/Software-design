namespace OrdersService.Messaging;
public interface IMessageBus
{
    void Publish(string queue, string message);
}
