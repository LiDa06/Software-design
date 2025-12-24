using System.ComponentModel.DataAnnotations;

namespace OrdersService.Models;

public class OutboxMessage
{
    public Guid Id { get; set; }

    public string Type { get; set; } = null!;

    public string Payload { get; set; } = null!;

    public bool Processed { get; set; }
}
