using TodoApi.Apis.Endpoints;

namespace TodoApi.Extensions;

public static class ApiExtensions
{
    public static void AddApis(this IServiceCollection services)
    {
        services.AddEndpoints();
    }
}
