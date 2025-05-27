namespace TodoApi.Models;

public record TaskItemResponse
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
}
