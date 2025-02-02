using FIF.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIF.Persistence.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Sex).IsRequired();
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(pa => pa.Country).HasMaxLength(50).IsRequired();
                a.Property(pa => pa.County).HasMaxLength(50).IsRequired();
                a.Property(pa => pa.Location).HasMaxLength(50).IsRequired();
                a.Property(pa => pa.Street).HasMaxLength(50).IsRequired();
                a.Property(pa => pa.HouseNumber).HasMaxLength(10).IsRequired();
            });
        }
    }
}
