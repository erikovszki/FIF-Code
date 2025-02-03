using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIF.Domain.Persons
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; } 
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public Sex Sex { get; set; }
        public required PersonAddress Address { get; set; }
    }

    public enum Sex
    {
        Female = 1,
        Male = 2
    }
}
