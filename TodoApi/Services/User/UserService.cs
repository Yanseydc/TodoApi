using ErrorOr;
using TodoApi.Data.Dal.UserDal;
using TodoApi.Data.Entities;
using TodoApi.Services.User.Mappers;
using TodoApi.Services.User.Models;
using TodoApi.Services.User.Utils;

namespace TodoApi.Services.User;

public class UserService(IUserDal userDal) : IUserService
{
    public async Task<ErrorOr<List<UserDto>>> GetUsersAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var result = await userDal.GetAllUsers(cancellationToken);
            return result.Match<ErrorOr<List<UserDto>>>(
                userEntityList => userEntityList.Select(user => user.MapToDto()).ToList(),
                errors => errors
            );
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<UserDto>> GetUserByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var result = await userDal.GetUserById(userId, cancellationToken);
            return result.Match<ErrorOr<UserDto>>(
                userEntity => userEntity.MapToDto(),
                errors => errors
            );
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<UserDto>> CreateUserAsync(
        UserRequestDto userDto,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var userEntity = new UserEntity
            {
                Username = userDto.Username,
                Role = 1,
                HashedPassword = UseServiceUtils.HashPassword(userDto.Password),
            };
            var result = await userDal.CreateUser(userEntity, cancellationToken);
            return result.Match<ErrorOr<UserDto>>(entity => entity.MapToDto(), errors => errors);
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }
}
