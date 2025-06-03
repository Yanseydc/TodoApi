using TodoApi.Apis.AuthApi.Models;
using TodoApi.Apis.Constants;
using TodoApi.Apis.Endpoints;
using TodoApi.Services.Authentication;

namespace TodoApi.Apis.AuthApi;

public class AuthApi : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup(Routes.AuthRoute);

        apiGroup.MapPost("/login", Login).WithName("Login").WithTags("Auth");
    }

    internal static async Task<IResult> Login(
        LoginRequest request,
        IAuthService authService,
        CancellationToken cancellationToken = default
    )
    {
        /*var user = await db.Users.SingleOrDefaultAsync(u => u.Username == request.Username);
        if (user is null)
            return Results.Unauthorized();

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Results.Unauthorized();*/

        // var token = authService.BuildToken(user);
        // return Results.Ok(new { Token = token });
        return Results.Ok();
    }
}
