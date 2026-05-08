using TaskCaseAPI.DTOs;

namespace TaskCaseAPI.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
