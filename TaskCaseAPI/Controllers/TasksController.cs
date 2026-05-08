using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskCaseAPI.DTOs;
using TaskCaseAPI.Models;
using TaskCaseAPI.Services;

namespace TaskCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var tasks = await _taskService.GetAllAsync(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = GetUserId();

            var task = await _taskService.GetByIdAsync(id, userId);

            if (task is null)
                return NotFound("Task not found");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var userId = GetUserId();

            await _taskService.CreateAsync(dto,userId);
            return Ok("Task created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTaskDto dto)
        {
            var userId = GetUserId();

            var result = await _taskService.UpdateAsync(dto,userId);

            if (!result)
                return NotFound("Task not found");

            return Ok("Task updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();

            await _taskService.DeleteAsync(id, userId);
            return Ok("Task deleted");
        }
    }
}
