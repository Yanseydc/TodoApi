namespace TodoApi.Data.Entities;

public class TaskItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string? Title { get; init; } = string.Empty;
}