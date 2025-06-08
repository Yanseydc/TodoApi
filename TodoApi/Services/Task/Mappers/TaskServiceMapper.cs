using TodoApi.Data.Entities;
using TodoApi.Services.Task.Models;

namespace TodoApi.Services.Task.Mappers;

public static class TaskServiceMapper
{
    public static TaskEntity MapToEntity(this TaskRequestDto dto)
    {
        return new TaskEntity { Id = Guid.NewGuid(), Title = dto.Title };
    }

    public static TaskDto MapToDto(this TaskEntity entity)
    {
        return new TaskDto { Id = entity.Id, Title = entity.Title };
    }
}
