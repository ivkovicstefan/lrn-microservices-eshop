var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddCarter();

var app = builder.Build();

// Configure HTTP pipeline
app.MapCarter();

app.Run();