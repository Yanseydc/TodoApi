using System.ComponentModel.DataAnnotations;

namespace TodoApi.Extensions;

public class JwtSettings
{
    [Required]
    public string Key { get; set; } = null!;

    [Required]
    public string Issuer { get; set; } = null!;

    [Required]
    public string Audience { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Duration should be greater than 0")]
    public int DurationInMinutes { get; set; }
}
