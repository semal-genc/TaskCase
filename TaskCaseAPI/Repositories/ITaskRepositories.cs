using TaskCaseAPI.Models;

namespace TaskCaseAPI.Repositories
{
    public interface ITaskRepositories
    {
        Task<List<UserTask>> GetAllAsync(int userId);
        Task<UserTask?> GetByIdAsync(int id,int userId);
        Task<List<UserTask>> GetByUserIdAsync(int userId);
        Task CreateAsync(UserTask task);
        Task UpdateAsync(UserTask task);
        Task DeleteAsync(UserTask task);
    }
}
