namespace TodoApi.Data.Dal.UserDal.Extensions;

public static class UserExtensions
{
    public static void AddUserDal(this IServiceCollection services)
    {
        services.AddScoped<IUserDal, UserDal>();
    }
}
