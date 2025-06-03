using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Extensions;

public static class DbContextExtensions
{
    public static void AddDbContextExtension(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=tasks.db"));
    }
}
