using TodoApi.Apis.TaskApi.Models;
using TodoApi.Services.Task.Models;

namespace TodoApi.Apis.TaskApi.Mappers;

public static class TaskApiMappers
{
    public static TaskDto MapToDto(this TaskItemRequest task)
    {
        return new TaskDto
        {
            Title = task.Title
        };
    }
    
}