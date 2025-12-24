using Microsoft.EntityFrameworkCore;
using OrdersService.Data;
using OrdersService.Messaging;
using OrdersService.Background;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<OrdersDbContext>(options =>
    options.UseNpgsql("Host=postgres;Database=shop;Username=shop;Password=shop"));

// RabbitMQ
builder.Services.AddSingleton<IMessageBus, RabbitMqBus>();

// Outbox background worker
builder.Services.AddHostedService<OutboxPublisher>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();

