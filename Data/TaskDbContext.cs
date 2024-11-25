using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext (DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskItem> Task { get; set; } = default!;
    }
}
