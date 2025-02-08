using AutoMapper;
using FIF.Application.DTOs;
using FIF.Application.Services;
using FIF.Registration.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIF.Registration.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await _userService.LoginUserAsync(login.Email, login.Password);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index", new LoginViewModel { Login = login, ErrorMessage = result.Errors.Select(s => s.Message).FirstOrDefault()});
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new UserRegistrationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistration registration)
        {
            var result = await _userService.RegisterUserAsync(_mapper.Map<RegisterUserDto>(registration));
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Registration", new UserRegistrationViewModel { Registration = registration, ErrorMessage = result.Errors.Select(s => s.Message).FirstOrDefault() });
        }
    }
}
