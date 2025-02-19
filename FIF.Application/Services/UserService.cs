using FIF.Application.Constants;
using FIF.Application.DTOs;
using FIF.Domain.User;
using FluentResults;
using Microsoft.AspNetCore.Identity;


namespace FIF.Application.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Result> LoginUserAsync(string email, string password)
        {
            var res = await _signInManager.PasswordSignInAsync(email, password, true, false);
            return res.Succeeded ? Result.Ok() : Result.Fail(FalingCases.LoginFailed);
        }

        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Result> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            if (registerUserDto.PasswordFirst != registerUserDto.PasswordSecond)
            {
                return Result.Fail(FalingCases.PasswordsDoNotMatch);
            }

            var creationResult = await _userManager.CreateAsync(new User { UserName = registerUserDto.Email, Email = registerUserDto.Email }, registerUserDto.PasswordFirst);
            if (creationResult.Succeeded)
            {
                var singinResult = await _signInManager.PasswordSignInAsync(registerUserDto.Email, registerUserDto.PasswordFirst, true, false);
                return singinResult.Succeeded ? Result.Ok() : Result.Fail(FalingCases.LoginFailed);
            }
            return Result.Fail(FalingCases.RegistrationFailed);
        }
    }
}
