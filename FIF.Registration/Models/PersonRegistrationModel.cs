using FIF.Application.DTOs;

namespace FIF.Registration.Models
{
    public class PersonRegistrationModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }// TODO: we should remove this field
        public required string Phone { get; set; }
        public required string PersonalIdentificationNumber { get; set; } //CNP
        public required Sex Sex { get; set; }
        public required DateTime BirthDate { get; set; }
        public required TShrtSize TShrtSize { get; set; }
        public required MealPreferences MealPreferences { get; set; }
        public required Religion Religion { get; set; }
        public required string Country { get; set; }
        public required string County { get; set; }
        public required string Location { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
    }
}
