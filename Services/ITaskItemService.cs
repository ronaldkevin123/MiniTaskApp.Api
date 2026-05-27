using MiniTaskApp.Api.DTOs;

namespace MiniTaskApp.Api.Services
{
    public interface ITaskItemService
    {
        Task<TaskItemDto?> AddTaskItemAsync(int taskId, TaskItemDto dto);
        Task<bool> UpdateTaskItemAsync(int id, TaskItemDto dto);
        Task<bool> DeleteTaskItemAsync(int id);
    }
}