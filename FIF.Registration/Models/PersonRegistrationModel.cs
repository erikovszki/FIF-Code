using FIF.Application.DTOs;

namespace FIF.Registration.Models
{
    public class PersonRegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }// TODO: we should remove this field
        public string Phone { get; set; }
        public string PersonalIdentificationNumber { get; set; } //CNP
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public TShrtSize TShrtSize { get; set; }
        public MealPreferences MealPreferences { get; set; }
        public Religion Religion { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Location { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
