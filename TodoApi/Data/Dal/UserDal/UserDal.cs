using System.ComponentModel.DataAnnotations;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Entities;

namespace TodoApi.Data.Dal.UserDal;

public class UserDal(AppDbContext dbContext) : IUserDal
{
    public async Task<ErrorOr<List<UserEntity>>> GetAllUsers(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            return await dbContext.Users.ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<UserEntity>> GetUserById(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var user = await dbContext.Users.FindAsync([id, cancellationToken], cancellationToken);
            if (user is null)
            {
                return Error.Failure(description: "User not found");
            }

            return user;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<UserEntity>> CreateUser(
        UserEntity user,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var context = new ValidationContext(user, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                return Error.Failure(description: "Validation failed");
            }

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }
}
