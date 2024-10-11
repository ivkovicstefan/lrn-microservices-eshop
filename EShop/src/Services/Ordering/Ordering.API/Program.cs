using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure HTTP Pipeline
app.UseApiServices();

app.Run();
