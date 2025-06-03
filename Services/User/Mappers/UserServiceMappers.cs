using TodoApi.Data.Entities;
using TodoApi.Services.User.Models;

namespace TodoApi.Services.User.Mappers;

public static class UserServiceMappers
{
    public static UserDto MapToDto(this UserEntity userEntity)
    {
        return new UserDto
        {
            Id = userEntity.Id,
            Username = userEntity.Username,
            HashedPassword = userEntity.HashedPassword,
            Role = userEntity.Role,
        };
    }
}
