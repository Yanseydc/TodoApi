using System.ComponentModel.DataAnnotations;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Entities;

namespace TodoApi.Data.Dal.TaskDal;

public class TaskDal(AppDbContext dbContext) : ITaskDal
{
    public async Task<ErrorOr<List<TaskEntity>>> GetAllTasks(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            return await dbContext.Tasks.ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<TaskEntity>> GetTaskById(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var task = await dbContext.Tasks.FindAsync([id, cancellationToken], cancellationToken);
            return task is null ? Error.Failure(description: "Task not found") : task;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public async Task<ErrorOr<TaskEntity>> CreateTask(
        TaskEntity task,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var context = new ValidationContext(task, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(task, context, results, true))
            {
                return Error.Failure(description: "Validation failed");
            }
            dbContext.Tasks.Add(task);
            await dbContext.SaveChangesAsync(cancellationToken);
            return task;
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
