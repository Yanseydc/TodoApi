using ErrorOr;
using TodoApi.Data.Entities;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task;

public interface ITaskService
{
    Task<ErrorOr<List<TaskEntity>>> GetTasks(CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskEntity>> GetTaskById(Guid id, CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskEntity>> CreateTask(
        TaskDto task,
        CancellationToken cancellationToken = default
    );
    Task<ErrorOr<Success>> DeleteTask(Guid id, CancellationToken cancellationToken = default);
}
