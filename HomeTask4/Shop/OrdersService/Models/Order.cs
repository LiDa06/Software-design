namespace OrdersService.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public long Amount { get; set; }
    public string Status { get; set; } = "NEW";
}
