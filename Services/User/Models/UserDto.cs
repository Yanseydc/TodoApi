namespace TodoApi.Services.User.Models;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public int? Role { get; set; }
}
