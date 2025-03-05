namespace FIF.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; } //TODO: remove this field later
        public required string Phone { get; set; }
        public required string PersonalIdentificationNumber { get; set; } //CNP
        public required Sex Sex { get; set; }
        public required PersonAddress Address { get; set; }
        public required DateTime BirthDate { get; set; }
        public required TShrtSize TShrtSize { get; set; }
        public required MealPreferences MealPreferences { get; set; }
        public required Religion Religion { get; set; }
    }
}
