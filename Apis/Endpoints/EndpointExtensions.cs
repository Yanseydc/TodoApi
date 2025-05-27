namespace TodoApi.Apis.Endpoints;

public static class EndpointExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<IEndpoint>()
            .AddClasses(classes => classes
                .AssignableTo<IEndpoint>()
                .Where(t => t is { IsAbstract: false, IsInterface: false })
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }

    public static void MapEndpoint(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoints(builder);
        }
    } 
}