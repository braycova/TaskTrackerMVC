using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models;

public class TaskItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    [EnumDataType(typeof(Priority))]
    public Priority Priority { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly TargetDate { get; set; }
}