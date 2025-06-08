using System.Security.Cryptography;
using System.Text;

namespace TodoApi.Services.User.Utils;

public static class UseServiceUtils
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        var sb = new StringBuilder();
        foreach (var b in hash)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
}
