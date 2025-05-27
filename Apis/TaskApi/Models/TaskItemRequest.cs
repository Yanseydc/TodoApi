using System.ComponentModel.DataAnnotations;

namespace TodoApi.Apis.TaskApi.Models;

public record TaskItemRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();

    [Required]
    [StringLength(100)]
    public required string Title { get; init; }
}
