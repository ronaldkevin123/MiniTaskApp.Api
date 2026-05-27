using Microsoft.AspNetCore.Mvc;
using MiniTaskApp.Api.DTOs;
using MiniTaskApp.Api.Services;

namespace MiniTaskApp.Api.Controllers
{
    [ApiController]
    [Route("api/taskitems")]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemsController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        // POST: api/tasks/{taskId}/items
        [HttpPost("{taskId}/items")]
        public async Task<ActionResult<TaskItemDto>> AddTaskItem(int taskId, TaskItemDto dto)
        {
            var item = await _taskItemService.AddTaskItemAsync(taskId, dto);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // PUT: api/taskitems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskItem(int id, TaskItemDto dto)
        {
            var updated = await _taskItemService.UpdateTaskItemAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/taskitems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var deleted = await _taskItemService.DeleteTaskItemAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}