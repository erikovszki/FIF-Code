using AutoMapper;
using FIF.Application.DTOs;
using FIF.Registration.Models;

namespace FIF.Registration.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonRegistrationModel, PersonDto>()
                .ForPath(d => d.Address.Country, s => s.MapFrom(m => m.Country))
                .ForPath(d => d.Address.County, s => s.MapFrom(m => m.County))
                .ForPath(d => d.Address.Location, s => s.MapFrom(m => m.Location))
                .ForPath(d => d.Address.Street, s => s.MapFrom(m => m.Street))
                .ForPath(d => d.Address.HouseNumber, s => s.MapFrom(m => m.HouseNumber))
                .ReverseMap();
        }
    }
}
