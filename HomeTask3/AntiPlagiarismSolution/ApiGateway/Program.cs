var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("storage", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["StorageServiceUrl"]!);
});

builder.Services.AddHttpClient("analysis", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["AnalysisServiceUrl"]!);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();