using System.ComponentModel.DataAnnotations;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Entities;
using TodoApi.Services.Task.Mappers;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task;

public class TaskService(AppDbContext dbContext) : ITaskService
{
    public async Task<ErrorOr<List<TaskItem>>> GetTasks(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var tasks = await dbContext
                .Tasks.ToListAsync(cancellationToken: cancellationToken);
            return tasks;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<TaskItem>> GetTaskById(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var task = await dbContext.Tasks.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            return task is null ? Error.Failure(description: "Task not found") : task;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<TaskItem>> CreateTask(
        TaskDto task,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var taskEntity = task.MapToEntity();
            var context = new ValidationContext(taskEntity, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(taskEntity, context, results, true))
            {
                return Error.Failure(description: "Validation failed");
            }

            dbContext.Tasks.Add(taskEntity);
            await dbContext.SaveChangesAsync(cancellationToken);
            return taskEntity;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<Success>> DeleteTask(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var task = await dbContext.Tasks.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            if (task is null)
            {
                return Error.Failure(description: "Task not found");
            }

            var context = new ValidationContext(task, null, null);
            context.MemberName = "Id";

            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Result.Success;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }
}
