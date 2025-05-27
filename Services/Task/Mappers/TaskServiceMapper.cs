using TodoApi.Data.Entities;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task.Mappers;

public static class TaskServiceMapper
{
    public static TaskItem MapToEntity(this TaskDto dto)
    {
        return new TaskItem { Title = dto.Title };
    }
}
