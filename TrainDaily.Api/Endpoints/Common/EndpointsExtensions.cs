namespace TrainDaily.Api.Endpoints.Common;

public static class EndpointsExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssembliesOf(typeof(IEndpoint))
                .AddClasses(classes => classes.AssignableTo<IEndpoint>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()
        );
    }

    public static void MapEndpoints(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var endpoints = scope.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();
        var builder = app.MapGroup("/api/");

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndPoint(builder);
        }
    }
}
