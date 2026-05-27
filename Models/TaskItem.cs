namespace MiniTaskApp.Api.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public int TaskId { get; set; }
        public virtual required Task Task { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public Enums.TaskItemStatus Status { get; set; }
        public int? EmployeeId { get; set; }
        public virtual required Employee Employee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}