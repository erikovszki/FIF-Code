using AutoMapper;
using FIF.Application.DTOs;
using FIF.Registration.Models;

namespace FIF.Registration.Profiles
{
    public class UserRegistrationProfile : Profile
    {
        public UserRegistrationProfile()
        {
            CreateMap<UserRegistration, RegisterUserDto>();
            CreateMap<RegisterUserDto, UserRegistration>();
        }
    }
}
