using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrdersService.Models;

namespace OrdersService.Data;

public class OrdersDbContext(DbContextOptions<OrdersDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OutboxMessage> Outbox => Set<OutboxMessage>();
}
