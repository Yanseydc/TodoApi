namespace TodoApi.Data.Dal.TaskDal.Extensions;

public static class TaskExtensions
{
    public static void AddTaskDal(this IServiceCollection services)
    {
        services.AddScoped<ITaskDal, TaskDal>();
    }
}
