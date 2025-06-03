using ErrorOr;
using TodoApi.Services.User.Models;

namespace TodoApi.Services.User;

public interface IUserService
{
    Task<ErrorOr<IEnumerable<UserDto>>> GetUsersAsync(
        CancellationToken cancellationToken = default
    );
    Task<ErrorOr<UserDto>> GetUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<ErrorOr<UserDto>> CreateUserAsync(
        UserRequestDto userDto,
        CancellationToken cancellationToken = default
    );
}
