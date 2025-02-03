using AutoMapper;
using FIF.Application.DTOs;
using FIF.Domain;
using FIF.Domain.Persons;

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
    }
}
