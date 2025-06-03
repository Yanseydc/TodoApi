using TodoApi.Services.User.Models;

namespace TodoApi.Services.Authentication;

public interface IAuthService
{
    string BuildToken(UserDto userEntity);
}
