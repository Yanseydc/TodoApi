namespace TodoApi.Data.Entities;

public class UserEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string? Username { get; init; } = string.Empty;
    public int? Role { get; init; } = 1;
    public string? HashedPassword { get; init; } = string.Empty;
}
