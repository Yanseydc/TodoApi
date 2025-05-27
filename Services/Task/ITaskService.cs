using ErrorOr;
using TodoApi.Data.Entities;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task;

public interface ITaskService
{
    Task<ErrorOr<List<TaskItem>>> GetTasks(CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskItem>> GetTaskById(Guid id, CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskItem>> CreateTask(TaskDto task, CancellationToken cancellationToken = default);
    Task<ErrorOr<Success>> DeleteTask(Guid id, CancellationToken cancellationToken = default);
}
