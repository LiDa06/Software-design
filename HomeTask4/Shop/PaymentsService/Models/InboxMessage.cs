namespace PaymentsService.Models;
public class InboxMessage
{
    public Guid MessageId { get; set; }
    public DateTime ProcessedAt { get; set; }
}
