using Microsoft.EntityFrameworkCore;
using PaymentsService.Data;
using PaymentsService.Messaging;
using PaymentsService.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db
builder.Services.AddDbContext<PaymentsDbContext>(options =>
    options.UseNpgsql("Host=postgres;Database=shop;Username=shop;Password=shop"));

// RabbitMQ
builder.Services.AddSingleton<IMessageBus, RabbitMqBus>();
builder.Services.AddSingleton<RabbitMqListener>();

// Consumers
builder.Services.AddHostedService<OrderCreatedConsumer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
