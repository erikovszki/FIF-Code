using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIF.Registration.Models
{
    public class LoginViewModel
    {
        public Login Login { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
