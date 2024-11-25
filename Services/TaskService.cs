using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Services;

public class TaskService
{
    private const string FilePath = "Data/tasks.json";

    public List<TaskItem> GetTasks()
    {
        if (!File.Exists(FilePath)) return new List<TaskItem>();
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void SaveTasks(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(FilePath, json);
    }

    public void AddTask(TaskItem task)
    {
        var tasks = GetTasks();
        task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
        tasks.Add(task);
        SaveTasks(tasks);
    }

    public void DeleteTask(int taskId)
    {
        var tasks = GetTasks();
        TaskItem task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            tasks.Remove(task);
            SaveTasks(tasks);
        }
    }
    
}