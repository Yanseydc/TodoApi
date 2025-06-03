namespace TodoApi.Services.Authentication.Extensions;

public static class AuthExtensions
{
    public static void AddAuthService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
    }
}
