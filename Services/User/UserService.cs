using System.ComponentModel.DataAnnotations;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Entities;
using TodoApi.Services.User.Mappers;
using TodoApi.Services.User.Models;
using TodoApi.Services.User.Utils;

namespace TodoApi.Services.User;

public class UserService(AppDbContext dbContext) : IUserService
{
    public async Task<ErrorOr<IEnumerable<UserDto>>> GetUsersAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var result = await dbContext.Users.ToListAsync(cancellationToken);
            return result.Select(user => user.MapToDto()).ToErrorOr();
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<UserDto>> GetUserAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var user = await dbContext.Users.FindAsync(
                [userId, cancellationToken],
                cancellationToken
            );
            if (user is null)
            {
                return Error.Failure(description: "User not found");
            }

            return user.MapToDto();
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
            var context = new ValidationContext(userEntity, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(userEntity, context, results, true))
            {
                return Error.Failure(description: "Validation failed");
            }

            dbContext.Users.Add(userEntity);
            await dbContext.SaveChangesAsync(cancellationToken);
            return userEntity.MapToDto();
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }
}
