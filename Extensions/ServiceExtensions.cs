using TodoApi.Services.Task.Extensions;

namespace TodoApi.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTaskService();
    }
}