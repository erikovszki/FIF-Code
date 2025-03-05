using FIF.Application.DTOs;
using FIF.Registration.Models;
using FIF.Registration.Validators;

namespace FIF.Tests.Validators
{
    public class PersonRegistrationModelValidatorTests : ValidatorTestBase
    {
        public IEnumerable<PersonRegistrationModel> InValidDTOs =>
        new List<PersonRegistrationModel>()
        {
            new PersonRegistrationModel
                {
                    FirstName = "", // Invalid: Empty first name
                    LastName = "", // Invalid: Empty last name
                    Email = "invalid-email", // Invalid: Incorrect email format
                    Phone = "123", // Invalid: Too short
                    PersonalIdentificationNumber = "123456789", // Invalid: Incorrect format
                    Sex = (Sex)0, // Invalid: Undefined enum value
                    BirthDate = DateTime.Now.AddYears(1), // Invalid: Future date
                    TShrtSize = (TShrtSize)0, // Invalid: Undefined enum value
                    MealPreferences = (MealPreferences)0, // Invalid: Undefined enum value
                    Religion = (Religion)0, // Invalid: Undefined enum value
                    Country = "", // Invalid: Empty country
                    County = "", // Invalid: Empty county
                    Location = "", // Invalid: Empty location
                    Street = "", // Invalid: Empty street
                    HouseNumber = "" // Invalid: Empty house number
                },
                new PersonRegistrationModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "1234567890",
                    PersonalIdentificationNumber = "1234567890123",
                    Sex = Sex.Male,
                    BirthDate = DateTime.Now.AddYears(-25),
                    TShrtSize = TShrtSize.MaleM,
                    MealPreferences = MealPreferences.Normal,
                    Religion = Religion.Catolic,
                    Country = "Hakuna Matata",
                    County = "SomeCounty",
                    Location = "SomeLocation",
                    Street = "SomeStreet",
                    HouseNumber = "123"
                }
                //TODO: Add more invalid cases
        };

        public IEnumerable<PersonRegistrationModel> ValidDTOs =>
            new List<PersonRegistrationModel>()
            {
                new PersonRegistrationModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "1234567890",
                    PersonalIdentificationNumber = "1234567890123",
                    Sex = Sex.Male,
                    BirthDate = DateTime.Now.AddYears(-25),
                    TShrtSize = TShrtSize.MaleM,
                    MealPreferences = MealPreferences.Normal,
                    Religion = Religion.Catolic,
                    Country = "Romania",
                    County = "SomeCounty",
                    Location = "SomeLocation",
                    Street = "SomeStreet",
                    HouseNumber = "123"
                },        
                new PersonRegistrationModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "1234567890",
                    PersonalIdentificationNumber = "1234567890123",
                    Sex = Sex.Male,
                    BirthDate = DateTime.Now.AddYears(-25),
                    TShrtSize = TShrtSize.MaleM,
                    MealPreferences = MealPreferences.Normal,
                    Religion = Religion.Catolic,
                    Country = "Hungary",
                    County = "SomeCounty",
                    Location = "SomeLocation",
                    Street = "SomeStreet",
                    HouseNumber = "123"
                } 
                //TODO: Add more valid cases
            };

        [Theory]
        [MemberData(nameof(CreateTestData), new object[] { nameof(ValidDTOs), typeof(PersonRegistrationModelValidatorTests) })]
        public void Valid_ReturnsTrue(PersonRegistrationModel dTO)
        {
            // Arrange
            var validator = new PersonRegistrationModelValidator();

            // Act
            var result = validator.Validate(dTO);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory]
        [MemberData(nameof(CreateTestData), new object[] { nameof(InValidDTOs), typeof(PersonRegistrationModelValidatorTests) })]
        public void Invalid_ReturnsFalse(PersonRegistrationModel dTO)
        {
            // Arrange
            var validator = new PersonRegistrationModelValidator();

            // Act
            var result = validator.Validate(dTO);

            // Assert
            Assert.False(result.IsValid);
        }

    }
}
