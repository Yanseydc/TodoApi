namespace TodoApi.Services.Task.Models;

public class TaskDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; } = string.Empty;
}
