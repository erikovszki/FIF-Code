using AutoMapper;
using FIF.Application.Constants;
using FIF.Application.DTOs;
using FIF.Domain.Entities;
using FIF.Domain.Services;
using FluentResults;

namespace FIF.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDomainService _personDomainService;
        private readonly IMapper _mapper;

        public PersonService(IPersonDomainService personDomainService, IMapper mapper)
        {
            _personDomainService = personDomainService;
            _mapper = mapper;
        }

        public async Task<Result<PersonDto>> AddPersonAsync(PersonDto person)
        {
            var result = await _personDomainService.InsertAsync(_mapper.Map<Person>(person));
            return Result.Ok(_mapper.Map<PersonDto>(result));
        }

        public async Task<Result<bool>> PersonExistsAsync(string? email)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(email))
                {
                    return Result.Fail(FalingCases.InvalidEmail);
                }
                var person = await _personDomainService.GetByEmailAsync(email);
                return person != null ? Result.Ok(true) : Result.Ok(false);
            }
            catch (Exception)
            {
                return Result.Fail(FalingCases.DatabaseOperationFailed);
                //TODO: logging
            }
        }
        public async Task<Result<PersonDto>> GetPersonByEmailAsync(string email)
        {
            try
            {
                var person = await _personDomainService.GetByEmailAsync(email);
                if (person == null)
                {
                    return Result.Fail(FalingCases.PersonDoesNotExist);
                }
                return Result.Ok(_mapper.Map<PersonDto>(person));
            }
            catch (Exception)
            {
                return Result.Fail(FalingCases.DatabaseOperationFailed);
                //TODO: logging
            }
        }
    }
}
