using TaskCaseAPI.DTOs;
using TaskCaseAPI.Models;

namespace TaskCaseAPI.Services
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllAsync(int userId);
        Task<TaskDto?> GetByIdAsync(int id ,int userId);
        Task CreateAsync(CreateTaskDto dto, int userId);
        Task<bool> UpdateAsync(UpdateTaskDto dto, int userId);
        Task DeleteAsync(int id, int userId);
    }
}
