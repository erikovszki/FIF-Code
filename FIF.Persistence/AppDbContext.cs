using FIF.Domain;
using FIF.Domain.Persons;
using FIF.Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FIF.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<User>(options), IAppDbContext
    {

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
