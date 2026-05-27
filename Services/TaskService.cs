using Microsoft.EntityFrameworkCore;
using MiniTaskApp.Api.Data;
using MiniTaskApp.Api.DTOs;
using TaskModel = MiniTaskApp.Api.Models.Task;
using TaskItemModel = MiniTaskApp.Api.Models.TaskItem;

namespace MiniTaskApp.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDto?>> GetTasksAsync()
        {
            var tasks = await _context.Tasks.Include(t => t.TaskItems).ToListAsync();
            return tasks.Select(t => ToTaskDto(t)).ToList();
        }

        public async Task<TaskDto?> GetTaskAsync(int id)
        {
            var task = await _context.Tasks.Include(t => t.TaskItems).FirstOrDefaultAsync(t => t.TaskId == id);
            return task == null ? null : ToTaskDto(task);
        }

        public async Task<TaskDto> CreateTaskAsync(TaskDto dto)
        {
            var task = new TaskModel
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                TaskItems = []
            };

            _context.Tasks.Add(task);

            await _context.SaveChangesAsync();
            return ToTaskDto(task);
        }

        public async Task<bool> UpdateTaskAsync(int id, TaskDto dto)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.Include(t => t.TaskItems).FirstOrDefaultAsync(t => t.TaskId == id);
            if (task == null) return false;

            _context.TaskItems.RemoveRange(task.TaskItems);
            _context.Tasks.Remove(task);
            
            await _context.SaveChangesAsync();
            return true;
        }

        #region Private Helpers
        private TaskDto ToTaskDto(TaskModel task)
        {
            var items = task.TaskItems?.Select(ToTaskItemDto).ToList() ?? [];
            return new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                TaskItems = items,
                Status = ComputeStatus(items)
            };
        }

        private TaskItemDto ToTaskItemDto(TaskItemModel item)
        {
            return new TaskItemDto
            {
                TaskItemId = item.TaskItemId,
                TaskId = item.TaskId,
                ItemName = item.ItemName,
                Status = item.Status.ToString(),
                EmployeeId = item.EmployeeId,
                EmployeeName = item.Employee != null ? item.Employee.FirstName + " " + item.Employee.LastName : string.Empty,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }

        private static string ComputeStatus(List<TaskItemDto> items)
        {
            if (items == null || items.Count == 0) return "Empty";
            if (items.All(i => i.Status == "New")) return "New";
            if (items.All(i => i.Status == "Done")) return "Done";
            if (items.Any(i => i.Status == "InProgress")) return "InProgress";
            return "New";
        }
        #endregion
    }
}