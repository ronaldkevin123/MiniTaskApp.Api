using Microsoft.EntityFrameworkCore;
using MiniTaskApp.Api.Models;

namespace MiniTaskApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relationships and constraints can be configured here if needed
        }
    }
}