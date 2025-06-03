namespace TodoApi.Services.User.Extensions;

public static class UserServiceExtensions
{
    public static void AddUserService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}
