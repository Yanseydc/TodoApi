using System.ComponentModel.DataAnnotations;

namespace TodoApi.Apis.TaskApi.Models;

public record TaskItemRequest
{
    [Required]
    [StringLength(100)]
    public required string Title { get; init; }
}
