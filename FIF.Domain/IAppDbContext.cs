using FIF.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace FIF.Domain
{
    public interface IAppDbContext
    {
        DbSet<Person> Persons { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
