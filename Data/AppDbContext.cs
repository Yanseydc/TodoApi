using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Entities;

namespace TodoApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

}