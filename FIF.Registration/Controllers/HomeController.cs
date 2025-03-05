using FIF.Application.DTOs;
using FIF.Application.Services;
using FIF.Registration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIF.Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            //await _personService.AddPersonAsync(new PersonDto
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Email = "john.doe@example.com",
            //    Phone = "123-456-7890",
            //    Sex = SexEnum.Male,
            //   Address = new PersonAddressDto
            //    {
            //        Country = "USA",
            //        County = "Orange",
            //        Location = "Irvine",
            //        Street = "Main St",
            //        HouseNumber = "123"
            //    }
            //});
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
