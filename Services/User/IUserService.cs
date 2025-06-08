using ErrorOr;
using TodoApi.Services.User.Models;

namespace TodoApi.Services.User;

public interface IUserService
{
    Task<ErrorOr<List<UserDto>>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task<ErrorOr<UserDto>> GetUserByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    );
    Task<ErrorOr<UserDto>> CreateUserAsync(
        UserRequestDto userDto,
        CancellationToken cancellationToken = default
    );
}
