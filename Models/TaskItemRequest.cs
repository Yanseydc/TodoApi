using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public record TaskItemRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    [StringLength(100)]
    public string? Title { get; init; } = string.Empty;
}