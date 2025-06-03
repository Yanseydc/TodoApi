using TodoApi.Apis.User.Models;
using TodoApi.Services.User.Models;

namespace TodoApi.Apis.User.Mappers;

public static class UserApiMappers
{
    public static UserRequestDto MapToDto(this UserRequest request)
    {
        return new UserRequestDto { Username = request.Username, Password = request.Password };
    }
}
