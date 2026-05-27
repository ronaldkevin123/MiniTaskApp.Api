using System;
using System.Collections.Generic;

namespace MiniTaskApp.Api.DTOs
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<TaskItemDto> TaskItems { get; set; } = [];
        public string Status { get; set; } = string.Empty;
    }
}