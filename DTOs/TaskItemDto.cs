using System;

namespace MiniTaskApp.Api.DTOs
{
    public class TaskItemDto
    {
        public int TaskItemId { get; set; }
        public int TaskId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}