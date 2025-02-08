using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIF.Application.DTOs
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string PasswordFirst { get; set; }
        public string PasswordSecond { get; set; }
    }
}
