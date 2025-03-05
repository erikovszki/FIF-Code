
using FIF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIF.Domain.Services
{
    public class PersonDomainService : IPersonDomainService
    {
        private readonly IAppDbContext _context;
        public PersonDomainService(IAppDbContext context)
        {
            _context = context;
        }
        public Task<Person?> GetByEmailAsync(string email) => _context.Persons.FirstOrDefaultAsync(p => p.Email == email);

        public async Task<Person> InsertAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
