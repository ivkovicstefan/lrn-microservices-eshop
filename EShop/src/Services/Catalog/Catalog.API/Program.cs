using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogDb")!);
}).UseLightweightSessions();
if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("CatalogDb")!);

var app = builder.Build();

// Configure HTTP pipeline
app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
