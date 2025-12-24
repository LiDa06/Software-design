namespace PaymentsService.Models;

public class OrderCreatedEvent
{
    public Guid EventId { get; set; }
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public long Amount { get; set; }
}
