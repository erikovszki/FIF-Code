using AutoMapper;
using FIF.Application.Constants;
using FIF.Application.DTOs;
using FIF.Domain;
using FIF.Domain.Persons;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace FIF.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddPersonAsync(PersonDto person)
        {
            var p = _mapper.Map<Person>(person);
            _context.Persons.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task<Result<bool>> PersonExistsAsync(string email)
        {
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(p => p.Email == email);
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
                var person = await _context.Persons.FirstOrDefaultAsync(p => p.Email == email);
                if(person == null)
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
