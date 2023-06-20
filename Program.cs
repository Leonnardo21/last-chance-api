using LastChanceAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LastChanceContext>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
