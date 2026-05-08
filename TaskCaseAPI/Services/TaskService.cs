using Microsoft.EntityFrameworkCore;
using TaskCaseAPI.Data;
using TaskCaseAPI.DTOs;
using TaskCaseAPI.Models;
using TaskCaseAPI.Repositories;

namespace TaskCaseAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepositories _taskRepositories;

        public TaskService(ITaskRepositories taskRepositories)
        {
            _taskRepositories = taskRepositories;
        }

        public async Task CreateAsync(CreateTaskDto dto, int userId)
        {
            var task = new UserTask
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = userId,
                IsCompleted = false
            };

            await _taskRepositories.CreateAsync(task);
        }

        public async Task DeleteAsync(int id, int userId)
        {
            var task = await _taskRepositories.GetByIdAsync(id, userId);

            if (task == null)
                return;

            await _taskRepositories.DeleteAsync(task);
        }

        public async Task<List<TaskDto>> GetAllAsync(int userId)
        {
            var tasks = await _taskRepositories.GetAllAsync(userId);

            return tasks.Select(x => new TaskDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted
            }).ToList();
        }

        public async Task<TaskDto?> GetByIdAsync(int id, int userId)
        {
            var task = await _taskRepositories.GetByIdAsync(id, userId);

            if (task is null)
                return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            };
        }

        public async Task<bool> UpdateAsync(UpdateTaskDto dto, int userId)
        {
            var task = await _taskRepositories.GetByIdAsync(dto.Id, userId);

            if (task == null)
                return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.IsCompleted = dto.IsCompleted;

            await _taskRepositories.UpdateAsync(task);
            return true;
        }
    }
}
