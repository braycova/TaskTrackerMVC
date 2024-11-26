using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskService();
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var tasks = _taskService.GetTasks();
            return View(tasks);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Priority,TargetDate")] TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _taskService.AddTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // POST: Task/Delete/5  - Deletes task immediately from the Index
        public async Task<IActionResult> Delete(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
