using ErrorOr;
using TodoApi.Apis.Constants;
using TodoApi.Apis.Endpoints;
using TodoApi.Apis.TaskApi.Mappers;
using TodoApi.Apis.TaskApi.Models;
using TodoApi.Services.Task;

namespace TodoApi.Apis.TaskApi;

public class TaskApi : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup(Routes.TasksRoute);

        apiGroup.MapGet("/", GetTasks).WithName("GetTasks").WithTags("Tasks");

        apiGroup.MapGet("/{id:guid}", GetTask).WithName("GetTask").WithTags("Tasks");

        apiGroup.MapPost("/", CreateTask).WithName("CreateTask").WithTags("Tasks");

        apiGroup.MapDelete("/{id:guid}", DeleteTask).WithName("DeleteTask").WithTags("Tasks");
    }

    internal static async Task<IResult> GetTasks(
        ITaskService taskService,
        CancellationToken cancellationToken = default
    )
    {
        return await taskService
            .GetTasksAsync(cancellationToken)
            .Match(Results.Ok, Results.BadRequest);
    }

    internal static async Task<IResult> GetTask(
        Guid id,
        ITaskService taskService,
        CancellationToken cancellationToken = default
    )
    {
        return await taskService
            .GetTaskByIdAsync(id, cancellationToken)
            .Match(Results.Ok, Results.BadRequest);
    }

    internal static async Task<IResult> CreateTask(
        TaskItemRequest task,
        ITaskService taskService,
        CancellationToken cancellationToken = default
    )
    {
        return await taskService
            .CreateTaskAsync(task.MapToDto(), cancellationToken)
            .Match(response => Results.Created($"/{response.Id}", response), Results.BadRequest);
    }

    internal static async Task<IResult> DeleteTask(
        Guid id,
        ITaskService taskService,
        CancellationToken cancellationToken = default
    )
    {
        return await taskService
            .DeleteTaskAsync(id, cancellationToken)
            .Match(Results.Ok, Results.BadRequest);
    }
}
