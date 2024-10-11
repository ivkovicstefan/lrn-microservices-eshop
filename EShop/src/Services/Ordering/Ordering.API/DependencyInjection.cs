namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // TODO: Register Services
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            // TODO: Configure HTTP Pipeline
            return app;
        }
    }
}
