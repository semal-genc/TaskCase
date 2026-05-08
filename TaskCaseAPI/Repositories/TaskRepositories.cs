using Microsoft.EntityFrameworkCore;
using TaskCaseAPI.Data;
using TaskCaseAPI.Models;

namespace TaskCaseAPI.Repositories
{
    public class TaskRepositories : ITaskRepositories
    {
        private readonly AppDbContext _context;

        public TaskRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserTask task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserTask>> GetAllAsync(int userId)
        {
            return await _context.Tasks
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserTask?> GetByIdAsync(int id, int userId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task<List<UserTask>> GetByUserIdAsync(int userId)
        {
            return await _context.Tasks
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateAsync(UserTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
