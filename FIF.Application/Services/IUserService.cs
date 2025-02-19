using FIF.Application.DTOs;
using FluentResults;

namespace FIF.Application.Services
{
    public interface IUserService
    {
        Task<Result> LoginUserAsync(string email, string password);
        Task<Result> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task LogoutUserAsync();
    }
}
