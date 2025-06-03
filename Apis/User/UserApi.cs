using ErrorOr;
using TodoApi.Apis.Constants;
using TodoApi.Apis.Endpoints;
using TodoApi.Apis.User.Mappers;
using TodoApi.Apis.User.Models;
using TodoApi.Services.User;
using TodoApi.Services.User.Models;

namespace TodoApi.Apis.User;

public class UserApi : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup(Routes.UserRoute);

        apiGroup.MapGet("/", GetUsers).WithName("GetUsers").WithTags("User");
        apiGroup.MapGet("/{id:guid}", GetUserById).WithName("GetUserById").WithTags("User");
        apiGroup.MapPost("/", CreateUser).WithName("CreateUser").WithTags("User");
    }

    internal static async Task<IResult> GetUsers(
        IUserService userService,
        CancellationToken cancellationToken = default
    )
    {
        return await userService
            .GetUsersAsync(cancellationToken)
            .Match(Results.Ok, Results.BadRequest);
    }

    internal static async Task<IResult> GetUserById(
        Guid id,
        IUserService userService,
        CancellationToken cancellationToken = default
    )
    {
        return await userService
            .GetUserAsync(id, cancellationToken)
            .Match(Results.Ok, Results.BadRequest);
    }

    internal static async Task<IResult> CreateUser(
        UserRequest user,
        IUserService userService,
        CancellationToken cancellationToken = default
    )
    {
        return await userService
            .CreateUserAsync(user.MapToDto(), cancellationToken)
            .Match(response => Results.Created($"/{response.Id}", response), Results.BadRequest);
    }
}
