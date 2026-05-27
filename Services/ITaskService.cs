using MiniTaskApp.Api.DTOs;

namespace MiniTaskApp.Api.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto?>> GetTasksAsync();
        Task<TaskDto?> GetTaskAsync(int id);
        Task<TaskDto> CreateTaskAsync(TaskDto dto);
        Task<bool> UpdateTaskAsync(int id, TaskDto dto);
        Task<bool> DeleteTaskAsync(int id);
    }
}