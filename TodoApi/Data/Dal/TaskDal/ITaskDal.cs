using ErrorOr;
using TodoApi.Data.Entities;

namespace TodoApi.Data.Dal.TaskDal;

public interface ITaskDal
{
    Task<ErrorOr<List<TaskEntity>>> GetAllTasks(CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskEntity>> GetTaskById(Guid id, CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskEntity>> CreateTask(
        TaskEntity task,
        CancellationToken cancellationToken = default
    );
    Task<ErrorOr<Success>> DeleteTask(Guid id, CancellationToken cancellationToken = default);
}
