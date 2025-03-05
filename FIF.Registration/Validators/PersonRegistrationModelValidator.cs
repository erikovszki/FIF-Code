using FIF.Registration.Models;
using FluentValidation;

namespace FIF.Registration.Validators
{
    public class PersonRegistrationModelValidator : AbstractValidator<PersonRegistrationModel>
    {
        public PersonRegistrationModelValidator()
        {
            RuleFor(c => c.FirstName).NotNull().NotEmpty().WithMessage("First name is required");
            RuleFor(c => c.LastName).NotNull().NotEmpty().WithMessage("Last name is required");

            RuleFor(c => c.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Phone is required")
                .Matches(@"^\+40[1-9][0-9]{8,9}$|^\+36[1-9][0-9]{8}$|^\d{10}$")
                .WithMessage("Phone number is not valid");

            RuleFor(c => c.PersonalIdentificationNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Personal Identification Number is required")
                .Length(13)
                .WithMessage("Personal Identification Number must be numeric and exactly 13 digits long")
                .Matches(@"^\d{13}$")
                .WithMessage("Personal Identification Number must be numeric and exactly 13 digits long");

            RuleFor(c => c.Sex).IsInEnum().WithMessage("Sex is required");
            RuleFor(c => c.BirthDate).NotNull().NotEmpty().WithMessage("Birth date is required");
            RuleFor(c => c.TShrtSize).IsInEnum().WithMessage("T-shirt size is required");
            RuleFor(c => c.MealPreferences).IsInEnum().WithMessage("Meal preferences are required");
            RuleFor(c => c.Religion).IsInEnum().WithMessage("Religion is required");

            RuleFor(c => c.Country)
                 .NotNull()
                .NotEmpty()
                .WithMessage("Country is required")
                .Must(country => AllowedCountries.Contains(country))
                .WithMessage($"Country must be one of the predefined countries {string.Join(", ", AllowedCountries)}");

            RuleFor(c => c.County).NotNull().NotEmpty().WithMessage("County is required");
            RuleFor(c => c.Location).NotNull().NotEmpty().WithMessage("Location is required");
            RuleFor(c => c.Street).NotNull().NotEmpty().WithMessage("Street is required");
            RuleFor(c => c.HouseNumber).NotNull().NotEmpty().WithMessage("House number is required");
        }

        private static readonly List<string> AllowedCountries = new List<string>
        {
            "Romania",
            "Magyarorszag",
            "Ungaria",
            "Hungary",
            "Romania",
        };
    }
}
