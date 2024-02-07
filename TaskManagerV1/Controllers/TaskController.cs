using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerV1.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TaskController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _tasksService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var task = await _tasksService.GetTaskByIdAsync(taskId);
            if(task is null)
            {
                return NotFound("Invalid ID");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(Tasks task)
        {
            await _tasksService.CreateTaskAsync(task);
            return Ok(task);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var task = await _tasksService.DeleteTaskAsync(taskId);
            if(task is null)
            {
                return NotFound("Invalid ID");
            }
            return Ok($"Task {taskId} has been deleted.");
        }

        [HttpPatch("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, Tasks updatedTask)
        {
            var task = await _tasksService.UpdateTaskAsync(taskId, updatedTask);
            if(task is null)
            {
                return NotFound("Invalid Task ID");
            }
            return Ok(task);
        }
    }
}
