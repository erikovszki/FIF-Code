using AutoMapper;
using FIF.Application.DTOs;
using FIF.Domain.Persons;


namespace FIF.Application.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<PersonAddressDto, PersonAddress>();
        }
    }
}
