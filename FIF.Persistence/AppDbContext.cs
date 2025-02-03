using FIF.Domain;
using FIF.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace FIF.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options), IAppDbContext
    {

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
