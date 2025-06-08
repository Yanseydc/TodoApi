using ErrorOr;
using TodoApi.Data.Dal.TaskDal;
using TodoApi.Services.Task.Mappers;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task;

public class TaskService(ITaskDal taskDal) : ITaskService
{
    public async Task<ErrorOr<List<TaskDto>>> GetTasksAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var tasks = await taskDal.GetAllTasks(cancellationToken);
            return tasks.Match<ErrorOr<List<TaskDto>>>(
                taskEntities => taskEntities.Select(task => task.MapToDto()).ToList(),
                errors => errors
            );
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<TaskDto>> GetTaskByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var task = await taskDal.GetTaskById(id, cancellationToken);
            return task.Match<ErrorOr<TaskDto>>(
                taskEntity => taskEntity.MapToDto(),
                errors => errors
            );
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<TaskDto>> CreateTaskAsync(
        TaskRequestDto request,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var taskEntity = request.MapToEntity();
            var result = await taskDal.CreateTask(taskEntity, cancellationToken);
            return result.Match<ErrorOr<TaskDto>>(entity => entity.MapToDto(), errors => errors);
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<Success>> DeleteTaskAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var result = await taskDal.DeleteTask(id, cancellationToken);
            return result.Match<ErrorOr<Success>>(success => success, errors => errors);
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }
}
