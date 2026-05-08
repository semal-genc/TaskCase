using Microsoft.EntityFrameworkCore;
using TaskCaseAPI.Data;
using TaskCaseAPI.DTOs;
using TaskCaseAPI.Models;

namespace TaskCaseAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenService _tokenHandler;

        public AuthService(AppDbContext context, JwtTokenService tokenHandler)
        {
            _context = context;
            _tokenHandler = tokenHandler;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user is null)
                return "User not found";
            if (user.PasswordHash != dto.Password)
                return "Wrong password";

            var token = _tokenHandler.CreateAccessToken(user);

            return token.AccessToken;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return "User created";
        }
    }
}
