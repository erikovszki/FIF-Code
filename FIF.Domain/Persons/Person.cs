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
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
        public Sex Sex { get; set; }
        public PersonAddress Address { get; set; }
    }

    public enum Sex
    {
        Female = 1,
        Male = 2
    }
}
