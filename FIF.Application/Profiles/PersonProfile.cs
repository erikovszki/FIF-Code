using AutoMapper;
using FIF.Application.DTOs;
using FIF.Domain.Entities;

namespace FIF.Application.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>()
                .ForMember(p => p.Id, s => s.Ignore())
                .ReverseMap();
            CreateMap<PersonAddressDto, PersonAddress>()
                 .ReverseMap();

            CreateMap<Domain.Entities.Sex, DTOs.Sex>().ReverseMap();
            CreateMap<Domain.Entities.Religion, DTOs.Religion>().ReverseMap();
            CreateMap<Domain.Entities.TShrtSize, DTOs.TShrtSize>().ReverseMap();
            CreateMap<Domain.Entities.MealPreferences, DTOs.MealPreferences>().ReverseMap();
        }
    }
}
