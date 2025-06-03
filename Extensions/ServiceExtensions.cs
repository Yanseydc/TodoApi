using TodoApi.Services.Authentication.Extensions;
using TodoApi.Services.Task.Extensions;
using TodoApi.Services.User.Extensions;

namespace TodoApi.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTaskService();
        services.AddAuthService();
        services.AddUserService();
    }
}
