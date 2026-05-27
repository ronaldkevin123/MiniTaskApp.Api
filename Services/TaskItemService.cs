using MiniTaskApp.Api.Data;
using MiniTaskApp.Api.DTOs;
using TaskItemModel = MiniTaskApp.Api.Models.TaskItem;

namespace MiniTaskApp.Api.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly AppDbContext _context;
        public TaskItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItemDto?> AddTaskItemAsync(int taskId, TaskItemDto dto)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null) return null;
            
            var item = new TaskItemModel
            {
                TaskId = taskId,
                ItemName = dto.ItemName,
                Status = Enum.Parse<Enums.TaskItemStatus>(dto.Status),
                EmployeeId = dto.EmployeeId,
                CreatedAt = DateTime.UtcNow,
                Task = task!,
                Employee = null!
            };

            _context.TaskItems.Add(item);

            await _context.SaveChangesAsync();
            return ToTaskItemDto(item);
        }

        public async Task<bool> UpdateTaskItemAsync(int id, TaskItemDto dto)
        {
            var item = await _context.TaskItems.FindAsync(id);
            if (item == null) return false;

            item.ItemName = dto.ItemName;
            item.Status = Enum.Parse<Enums.TaskItemStatus>(dto.Status);
            item.EmployeeId = dto.EmployeeId;
            item.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskItemAsync(int id)
        {
            var item = await _context.TaskItems.FindAsync(id);
            if (item == null) return false;

            _context.TaskItems.Remove(item);
            
            await _context.SaveChangesAsync();
            return true;
        }

        #region Private Helpers
        private static TaskItemDto ToTaskItemDto(TaskItemModel item)
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
        #endregion
    }
}