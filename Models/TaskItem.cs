namespace TaskTracker.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public DateOnly TargetDate { get; set; }
}