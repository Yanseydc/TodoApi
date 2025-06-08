using ErrorOr;
using TodoApi.Data.Entities;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task;

public interface ITaskService
{
    Task<ErrorOr<List<TaskDto>>> GetTasksAsync(CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskDto>> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ErrorOr<TaskDto>> CreateTaskAsync(
        TaskRequestDto task,
        CancellationToken cancellationToken = default
    );
    Task<ErrorOr<Success>> DeleteTaskAsync(Guid id, CancellationToken cancellationToken = default);
}
