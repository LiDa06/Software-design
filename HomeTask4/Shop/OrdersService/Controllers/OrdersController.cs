using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OrdersService.Data;
using OrdersService.Models;

namespace OrdersService.Controllers;
public class OrdersController(OrdersDbContext db) : ControllerBase
{
    private readonly OrdersDbContext _db = db;

    public async Task<Guid> Create(
        Guid userId,
        long amount)
    {
        var order = new Order
        {
            UserId = userId,
            Amount = amount
        };

        var evt = new
        {
            EventId = Guid.NewGuid(),
            OrderId = order.Id,
            UserId = userId,
            Amount = amount
        };

        _db.Orders.Add(order);
        _db.Outbox.Add(new OutboxMessage
        {
            Type = "OrderCreated",
            Payload = JsonSerializer.Serialize(evt)
        });

        await _db.SaveChangesAsync();
        return order.Id;
    }
}
