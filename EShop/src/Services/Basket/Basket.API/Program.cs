var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("BasketDb")!);
    options.Schema.For<ShoppingCart>().Identity(sc => sc.UserName);
}).UseLightweightSessions();

var app = builder.Build();

// Configure HTTP pipeline
app.MapCarter();

app.Run();