using FIF.Registration.Models;
using FluentValidation;

namespace FIF.Registration.Validators
{
    public class PersonRegistrationViewModelValidator: AbstractValidator<PersonRegistrationViewModel>
    {
        public PersonRegistrationViewModelValidator()
        {
            RuleFor(m => m.Person).SetValidator(new PersonRegistrationModelValidator());
        }
    }
}
