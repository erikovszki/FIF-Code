using AutoMapper;
using FIF.Application.DTOs;
using FIF.Application.Services;
using FIF.Registration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIF.Registration.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;

        public PersonController(IMapper mapper, IPersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }


        [HttpGet]
        public async Task<IActionResult> GeneralRegistration()
        {
            var personExists = await _personService.PersonExistsAsync(User.Identity?.Name ?? null) ;
            if(personExists.IsFailed)
            {
                return View(new PersonRegistrationViewModel { ErrorMessage = personExists.Errors.First().Message });
            }
            
            if(personExists.Value)
            {
                return RedirectToAction("Index", "Home");
                //TODO: This will be the Edit page for the Person
                //TODO: After this we should redirect to the next step based on redirect URL OR we should redirect them to the Page where they can choose the Event
            }
            return View(new PersonRegistrationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGeneralRegistration(PersonRegistrationViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.ErrorMessage = "Invalid data";
                return View("GeneralRegistration", model);
            }

            var person = _mapper.Map<PersonDto>(model.Person);
            var result = await _personService.AddPersonAsync(person);
            if (result.IsFailed)
            {
                model.ErrorMessage = result.Errors.First().Message;
                return View("GeneralRegistration", model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
