using TodoApi.Data.Entities;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task.Mappers;

public static class TaskServiceMapper
{
    public static TaskEntity MapToEntity(this TaskDto dto)
    {
        return new TaskEntity { Title = dto.Title };
    }
}
