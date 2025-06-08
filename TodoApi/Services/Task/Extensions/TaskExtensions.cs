namespace TodoApi.Services.Task.Extensions;

public static class TaskExtensions
{
    public static void AddTaskService(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();
    }
}
