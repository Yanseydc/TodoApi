namespace TodoApi.Apis.User.Models;

public record UserRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
