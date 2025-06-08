namespace TodoApi.Services.User.Models;

public class UserRequestDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
