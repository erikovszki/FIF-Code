using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIF.Application.DTOs
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public SexEnum Sex { get; set; }
        public PersonAddressDto Address { get; set; }

    }
    public enum SexEnum
    {
        Female = 1,
        Male = 2
    }
    public class PersonAddressDto
    {
        public string Country { get; set; }
        public string County { get; set; }
        public string Location { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
