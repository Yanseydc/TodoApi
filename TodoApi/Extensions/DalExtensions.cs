using TodoApi.Data.Dal.TaskDal.Extensions;
using TodoApi.Data.Dal.UserDal.Extensions;

namespace TodoApi.Extensions;

public static class DalExtensions
{
    public static void AddDals(this IServiceCollection services)
    {
        services.AddUserDal();
        services.AddTaskDal();
    }
}
