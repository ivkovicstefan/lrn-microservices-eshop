var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Configure HTTP pipeline
app.MapReverseProxy();

app.Run();
