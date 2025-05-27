using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TodoApi.Apis.Constants;
using TodoApi.Apis.Endpoints;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Apis.TaskApi;

public class TaskApi : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup(Routes.TasksRoute);

        apiGroup
            .MapGet("/", GetTasks)
            .WithName("GetTasks")
            .WithTags("Tasks");
        
        apiGroup
            .MapGet("/{id:guid}", GetTask)
            .WithName("GetTask")
            .WithTags("Tasks");
        
        apiGroup
            .MapPost("/", CreateTask)
            .WithName("CreateTask")
            .WithTags("Tasks");

        apiGroup
            .MapDelete("/{id:guid}", DeleteTask)
            .WithName("DeleteTask")
            .WithTags("Tasks");

    }

    internal static async Task<IResult> GetTasks(
        AppDbContext db,
        CancellationToken cancellationToken = default
    )
    {
        return Results.Ok(await db.Tasks.ToListAsync(cancellationToken: cancellationToken));
    }

    internal static async Task<IResult> GetTask(
        AppDbContext db,
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var task = await db.Tasks.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        return task is null ? Results.NotFound() : Results.Ok(task);
    }

    internal static async Task<IResult> CreateTask(
        AppDbContext db,
        TaskItemRequest task,
        CancellationToken cancellationToken = default
        )
    {
        var context = new ValidationContext(task, null, null);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(task, context, results, true))
        {
            return Results.ValidationProblem(results.ToDictionary(
                e => e.MemberNames.First(),
                e => new[] { e.ErrorMessage ?? "" }));
        }

        db.Tasks.Add(task);
        await db.SaveChangesAsync(cancellationToken);
        return Results.Created($"/{task.Id}", task);
    }

    internal static async Task<IResult> DeleteTask(
        AppDbContext db,
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var task = await db.Tasks.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        if (task is null) return Results.NotFound();
        db.Tasks.Remove(task);
        await db.SaveChangesAsync(cancellationToken);
        return Results.NoContent();
    }
}