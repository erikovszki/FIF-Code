using AutoFixture;
using FIF.Application.Constants;
using FIF.Application.DTOs;
using FIF.Application.Services;
using FIF.Domain.Entities;
using FluentAssertions; //TODO: Change it in the future (the library has license costs for upper versions)
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Linq.Expressions;

namespace FIF.Tests.Application
{
    public class PersonServiceTests : ServiceTestsBase
    {
        private readonly IPersonService _sut;

        public PersonServiceTests() : base()
        {
            _sut = _fixture.Create<PersonService>();
        }
        [Fact]
        public async Task AddPersonAsync_ShouldReturnPersonDto_WhenPersonIsAdded()
        {
            // Arrange
            var person = _fixture.Create<Person>();
            var personDto = _mapper.Map<PersonDto>(person);

            _personDomainService.InsertAsync(Arg.Any<Person>()).Returns(person);

            // Act
            var result = await _sut.AddPersonAsync(personDto);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(personDto);
        }

        [Fact]
        public async Task PersonExistsAsync_ShouldReturnTrue_WhenPersonExists()
        {
            // Arrange
            var email = _fixture.Create<string>();
            var person = _fixture.Create<Person>();

            _personDomainService.GetByEmailAsync(Arg.Any<string>()).Returns(person);

            // Act
            var result = await _sut.PersonExistsAsync(email);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeTrue();
        }

        [Fact]
        public async Task PersonExistsAsync_ShouldReturnFalse_WhenPersonDoesNotExist()
        {
            // Arrange
            var email = _fixture.Create<string>();

            _personDomainService.GetByEmailAsync(Arg.Any<string>()).Returns(null as Person);

            // Act
            var result = await _sut.PersonExistsAsync(email);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeFalse();
        }

        [Fact]
        public async Task PersonExistsAsync_ShouldReturnError_WhenEmailIsWrong()
        {
            // Arrange

            // Act
            var result = await _sut.PersonExistsAsync(null);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.First().Message.Should().Be(FalingCases.InvalidEmail);
        }
        [Fact]
        public async Task GetPersonByEmailAsync_ShouldReturnPersonDto_WhenPersonExists()
        {
            // Arrange
            var email = _fixture.Create<string>();
            var person = _fixture.Create<Person>();
            var personDto =_mapper.Map<PersonDto>(person);

            _personDomainService.GetByEmailAsync(Arg.Any<string>()).Returns(person);

            // Act
            var result = await _sut.GetPersonByEmailAsync(email);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(personDto);
        }

        [Fact]
        public async Task GetPersonByEmailAsync_ShouldReturnFail_WhenPersonDoesNotExist()
        {
            // Arrange
            var email = _fixture.Create<string>();


            _personDomainService.GetByEmailAsync(Arg.Any<string>()).Returns(null as Person);

            // Act
            var result = await _sut.GetPersonByEmailAsync(email);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.First().Message.Should().Be(FalingCases.PersonDoesNotExist);
        }

    }
}
