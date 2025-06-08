using ErrorOr;
using TodoApi.Data.Entities;

namespace TodoApi.Data.Dal.UserDal;

public interface IUserDal
{
    Task<ErrorOr<List<UserEntity>>> GetAllUsers(CancellationToken cancellationToken = default);

    Task<ErrorOr<UserEntity>> GetUserById(Guid id, CancellationToken cancellationToken = default);

    Task<ErrorOr<UserEntity>> CreateUser(
        UserEntity user,
        CancellationToken cancellationToken = default
    );
}
