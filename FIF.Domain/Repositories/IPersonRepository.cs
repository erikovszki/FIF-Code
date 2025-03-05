using FIF.Domain.Entities;

namespace FIF.Domain.Services
{
    public interface IPersonRepository
    {
        Task<Person> InsertAsync(Person person);
        Task<Person?> GetByEmailAsync(string email);
    }
}
